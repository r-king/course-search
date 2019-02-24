using CourseSearch.Controllers.Api;
using CourseSearch.Core;
using CourseSearch.Core.Dtos;
using CourseSearch.Core.Models;
using CourseSearch.Core.Repositories;
using CourseSearch.Tests.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace CourseSearch.Tests.Controllers.Api
{
	[TestClass]
	public class ChannelsControllerTests
	{
		private string userId = "1";
		private ChannelsController controller;
		private Mock<IChannelRepository> channelRepository;
		private Mock<IChannelCourseRepository> channelCourseRepository;
		private Mock<ICourseRepository> courseRepository;

		[TestInitialize]
		public void TestInitialize()
		{
			channelRepository = new Mock<IChannelRepository>();
			channelCourseRepository = new Mock<IChannelCourseRepository>();
			courseRepository = new Mock<ICourseRepository>();

			var mockUoW = new Mock<IUnitOfWork>();
			mockUoW.Setup(u => u.Channels).Returns(channelRepository.Object);
			mockUoW.Setup(u => u.ChannelCourses).Returns(channelCourseRepository.Object);
			mockUoW.Setup(u => u.Courses).Returns(courseRepository.Object);

			controller = new ChannelsController(mockUoW.Object);

			controller.MockCurrentUser(userId, "user1@domian.com");
		}

		[TestMethod]
		public void Create_ChannelAlreadyExistsWithName_ShouldReturnBadRequest()
		{
			var channel = new Channel { Id = 1, Name = "ChannelName" };

			channelRepository.Setup(c => c.GetUserChannelByName(userId, "ChannelName")).Returns(channel);

			var result = controller.Create(new ChannelDto { Name = "ChannelName" });

			result.Should().BeOfType<BadRequestErrorMessageResult>();
		}

		[TestMethod]
		public void Remove_UserDoesNotOwnChannel_ShouldReturnUnautorized()
		{
			var channel = new Channel { Id = 1, UserId = "2" };

			channelRepository.Setup(c => c.GetChannel(1)).Returns(channel);

			var result = controller.Remove(1);

			result.Should().BeOfType<UnauthorizedResult>();
		}

		[TestMethod]
		public void Remove_ChannelDoesNotExist_ShouldReturnBadRequest()
		{
			Channel channel = null;

			channelRepository.Setup(c => c.GetChannel(1)).Returns(channel);

			var result = controller.Remove(1);

			result.Should().BeOfType<BadRequestErrorMessageResult>();
		}

		[TestMethod]
		public void AddCourse_ChannelDoesNotExist_ShouldReturnBadRequest()
		{
			Channel channel = null;

			channelRepository.Setup(c => c.GetChannel(1)).Returns(channel);

			var result = controller.AddCourse(new ChannelCourseDto { CourseId = 1, ChannelId = 1 });

			result.Should().BeOfType<BadRequestErrorMessageResult>();
		}

		[TestMethod]
		public void AddCourse_CourseDoesNotExist_ShouldReturnBadRequest()
		{
			Channel channel = new Channel { Id = 1, UserId = userId };

			channelRepository.Setup(c => c.GetChannel(1)).Returns(channel);

			Course course = null;

			courseRepository.Setup(c => c.GetCourse(1)).Returns(course);

			var result = controller.AddCourse(new ChannelCourseDto { CourseId = 1, ChannelId = 1 });

			result.Should().BeOfType<BadRequestErrorMessageResult>();
		}

		[TestMethod]
		public void AddCourse_UserDoesNotOwnChannel_ShouldReturnUnauthorized()
		{
			Channel channel = new Channel { Id = 1, UserId = "2" };

			channelRepository.Setup(c => c.GetChannel(1)).Returns(channel);

			var result = controller.AddCourse(new ChannelCourseDto { CourseId = 1, ChannelId = 1 });

			result.Should().BeOfType<UnauthorizedResult>();
		}

		[TestMethod]
		public void AddCourse_ChannelAlreadyContainsCourse_ShouldReturnBadRequest()
		{
			var channelCourse = new ChannelCourse { CourseId = 1, ChannelId = 1 };
			var channelCourseDto = new ChannelCourseDto { CourseId = 1, ChannelId = 1 };

			channelRepository.Setup(c => c.GetChannel(1)).Returns(new Channel { Id = 1, UserId = userId });
			courseRepository.Setup(c => c.GetCourse(1)).Returns(new Course { Id = 1 });
			channelCourseRepository.Setup(c => c.GetChannelCourse(1, 1)).Returns(channelCourse);

			var result = controller.AddCourse(channelCourseDto);

			result.Should().BeOfType<BadRequestErrorMessageResult>();
		}

		[TestMethod]
		public void RemoveCourse_ChannelDoesNotExist_ShouldReturnBadRequest()
		{
			Channel channel = null;
			channelRepository.Setup(c => c.GetChannel(1)).Returns(channel);

			var result = controller.RemoveCourse(new ChannelCourseDto { CourseId = 1, ChannelId = 1 });

			result.Should().BeOfType<BadRequestErrorMessageResult>();
		}

		[TestMethod]
		public void RemoveCourse_UserDoesNotOwnChannel_ShouldReturnUnauthorized()
		{
			Channel channel = new Channel { Id = 1, UserId = "2" };
			channelRepository.Setup(c => c.GetChannel(1)).Returns(channel);

			var result = controller.RemoveCourse(new ChannelCourseDto { ChannelId = 1, CourseId = 1 });

			result.Should().BeOfType<UnauthorizedResult>();
		}

		[TestMethod]
		public void RemoveCourse_ChannelCourseDoesNotExist_ShouldReturnNotFound()
		{
			Channel channel = new Channel { Id = 1, UserId = userId };
			channelRepository.Setup(c => c.GetChannel(1)).Returns(channel);

			ChannelCourse channelCourse = null;

			channelCourseRepository.Setup(c => c.GetChannelCourse(1, 1)).Returns(channelCourse);

			var result = controller.RemoveCourse(new ChannelCourseDto { ChannelId = 1, CourseId = 1 });

			result.Should().BeOfType<NotFoundResult>();
		}
	}
}