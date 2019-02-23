using CourseSearch.Core;
using CourseSearch.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace CourseSearch.Controllers
{
	public class CoursesController : Controller
	{
		private readonly IUnitOfWork unitOfWork;

		public CoursesController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		[HttpPost]
		public ActionResult Search(CoursesViewModel viewModel)
		{
			return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
		}

		[Authorize]
		public ViewResult Bookmarked()
		{
			var userId = User.Identity.GetUserId();

			var courses = unitOfWork.Courses
				.GetBookmarkedCourses(userId);

			var bookmarks = unitOfWork.Bookmarks.GetUserBookmarks(userId);

			var viewModel = new CoursesViewModel
			{
				Courses = courses,
				ShowActions = User.Identity.IsAuthenticated,
				Bookmarks = bookmarks.ToLookup(b => b.CourseId)
			};

			return View(viewModel);
		}

		public ViewResult PublisherCourses(int id)
		{
			var userId = User.Identity.GetUserId();

			var courses = unitOfWork.Courses
				.GetPublisherCourses(id);

			var bookmarks = unitOfWork.Bookmarks.GetUserBookmarks(userId);

			var viewModel = new PublisherCoursesViewModel
			{
				CoursesViewModel = new CoursesViewModel
				{
					Courses = courses,
					ShowActions = User.Identity.IsAuthenticated,
					Bookmarks = bookmarks.ToLookup(b => b.CourseId)
				},
				Publisher = unitOfWork.Publishers.GetPublisher(id)
			};

			return View(viewModel);
		}
	}
}