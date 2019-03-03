using CourseSearch.Core;
using CourseSearch.Core.Models;
using CourseSearch.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace CourseSearch.Controllers
{
	[Authorize]
	public class ChannelsController : Controller
	{
		private readonly IUnitOfWork unitOfWork;

		public ChannelsController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		// GET: Channels
		public ActionResult Index()
		{
			var userId = User.Identity.GetUserId();

			var channels = unitOfWork.Channels.GetUserChannels(userId);

			var viewModel = new ChannelsViewModel
			{
				Channels = channels
			};

			return View(viewModel);
		}

		public ActionResult Details(int id)
		{
			var userId = User.Identity.GetUserId();

			var channel = unitOfWork.Channels.GetChannel(id);

			if (channel == null)
				return new HttpNotFoundResult();

			if (channel.UserId != userId)
				return new HttpUnauthorizedResult();

			var courses = unitOfWork.ChannelCourses.GetCourses(id);

			var bookmarks = unitOfWork.Bookmarks.GetUserBookmarks(userId);

			var viewModel = new ChannelDetailsViewModel
			{
				Channel = channel,
				CoursesViewModel = new CoursesViewModel
				{
					Courses = courses,
					ShowActions = User.Identity.IsAuthenticated,
					Bookmarks = bookmarks.ToLookup(b => b.CourseId)
				}
			};

			return View(viewModel);
		}

		public ActionResult Create()
		{
			var viewModel = new ChannelFormViewModel
			{
				Heading = "Create Channel"
			};

			return PartialView(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ChannelFormViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return PartialView("Create", viewModel);
			}

			var userId = User.Identity.GetUserId();

			if (unitOfWork.Channels.GetUserChannelByName(userId, viewModel.Name) != null)
			{
				viewModel.ErrorMessage = "Channel already exists with this name";
				return PartialView("Create", viewModel);
			}

			var channel = new Channel
			{
				Name = viewModel.Name,
				Description = viewModel.Description,
				UserId = userId
			};

			unitOfWork.Channels.Create(channel);

			unitOfWork.Complete();

			return Json(new { redirectTo = Url.Action("Index", "Channels") });
		}

		public ActionResult Edit(int id)
		{
			var channel = unitOfWork.Channels.GetChannel(id);

			if (channel == null)
				return HttpNotFound();

			if (channel.UserId != User.Identity.GetUserId())
				return new HttpUnauthorizedResult();

			var viewModel = new ChannelFormViewModel
			{
				Id = channel.Id,
				Name = channel.Name,
				Description = channel.Description,
				Heading = "Edit Channel"
			};

			return PartialView("Create", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(ChannelFormViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return PartialView("Create", viewModel);
			}

			var channel = unitOfWork.Channels.GetChannel(viewModel.Id);

			if (channel == null)
				return HttpNotFound();

			if (channel.UserId != User.Identity.GetUserId())
				return new HttpUnauthorizedResult();

			channel.Modify(viewModel.Name, viewModel.Description);

			unitOfWork.Complete();

			return Json(new { redirectTo = Url.Action("Details", "Channels", new { channel.Id }) });
		}
	}
}