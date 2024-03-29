﻿using CourseSearch.Core;
using CourseSearch.Core.Dtos;
using CourseSearch.Core.Models;
using CourseSearch.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CourseSearch.Controllers.Api
{
	[Authorize]
	public class ChannelsController : ApiController
	{
		private readonly IUnitOfWork unitOfWork;

		public ChannelsController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		[Route("api/Channels/Create")]
		[HttpPost]
		public IHttpActionResult Create(ChannelDto dto)
		{
			var userId = User.Identity.GetUserId();

			if (unitOfWork.Channels.GetUserChannelByName(userId, dto.Name) != null)
				return BadRequest("Channel already exists with this name");

			var channel = new Channel
			{
				Name = dto.Name,
				Description = dto.Description,
				UserId = userId
			};

			unitOfWork.Channels.Create(channel);

			unitOfWork.Complete();

			return Ok();
		}

		[Route("api/Channels/Remove/{id}")]
		[HttpDelete]
		public IHttpActionResult Remove(int id)
		{
			var userId = User.Identity.GetUserId();

			var channel = unitOfWork.Channels.GetChannel(id);

			if (channel == null)
				return BadRequest("Channel does not exist");

			if (channel.UserId != userId)
				return Unauthorized();

			unitOfWork.Channels.Remove(channel);

			unitOfWork.Complete();

			return Ok();
		}

		[Route("api/Channels/AddCourse")]
		[HttpPost]
		public IHttpActionResult AddCourse(ChannelCourseDto dto)
		{
			var userId = User.Identity.GetUserId();

			var channel = unitOfWork.Channels.GetChannel(dto.ChannelId);

			if (channel == null)
				return BadRequest("Invalid Channel");

			if (channel.UserId != userId)
				return Unauthorized();

			var course = unitOfWork.Courses.GetCourse(dto.CourseId);

			if (course == null)
				return BadRequest("Invalid Course");

			var channelCourse = unitOfWork.ChannelCourses.GetChannelCourse(dto.ChannelId, dto.CourseId);

			if (channelCourse != null)
				return BadRequest("Channel already contains Course");

			unitOfWork.ChannelCourses.AddCourseToChannel(
				new ChannelCourse
				{
					ChannelId = dto.ChannelId,
					CourseId = dto.CourseId
				});

			unitOfWork.Complete();

			return Ok();
		}

		[Route("api/Channels/RemoveCourse")]
		[HttpDelete]
		public IHttpActionResult RemoveCourse(ChannelCourseDto dto)
		{
			var userId = User.Identity.GetUserId();

			var channel = unitOfWork.Channels.GetChannel(dto.ChannelId);

			if (channel == null)
				return BadRequest("Channel does not exist");

			if (channel.UserId != userId)
				return Unauthorized();

			var channelCourse = unitOfWork.ChannelCourses.GetChannelCourse(dto.ChannelId, dto.CourseId);

			if (channelCourse == null)
				return NotFound();

			unitOfWork.ChannelCourses.RemoveCourseFromChannel(channelCourse);

			unitOfWork.Complete();

			return Ok();
		}

		/// <summary>
		/// gets users list of channels which includes if course is in the channel
		/// </summary>
		/// <param name="id">id of course</param>
		/// <returns></returns>
		[Route("api/Channels/GetUserChannelsForCourse/{id}")]
		[HttpGet]
		public IHttpActionResult GetUserChannelsForCourse(int id)
		{
			var userId = User.Identity.GetUserId();

			IEnumerable<Channel> channels = unitOfWork.Channels.GetUserChannels(userId);

			var viewModel = new List<ChannelViewModel>();

			foreach (var channel in channels)
			{
				viewModel.Add(new ChannelViewModel
				{
					Id = channel.Id,
					Name = channel.Name,
					Selected = channel.ChannelCourses
					.Any(c => c.CourseId == id)
				});
			}

			return Json(viewModel);
		}
	}
}