using CourseSearch.Core;
using CourseSearch.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace CourseSearch.Controllers
{
	public class HomeController : Controller
	{
		private readonly IUnitOfWork unitOfWork;

		public HomeController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		/// <summary>
		/// number of records to return when quering courses
		/// </summary>
		private readonly int pageSize = 50;

		/// <summary>
		/// gets list of courses sorted by newest published date
		/// </summary>
		/// <param name="query">search querytext</param>
		/// <returns></returns>
		public ActionResult Index(string query = null)
		{
			var homeViewModel = new CoursesViewModel
			{
				Courses = null,
				SearchTerm = query
			};

			return View("Courses", homeViewModel);
		}

		/// <summary>
		/// gets next list of courses based on page size and page number
		/// </summary>
		/// <param name="page">page to get courses from</param>
		/// <param name="query">search query text</param>
		/// <returns></returns>
		public ActionResult GetCourses(int page, string query = null)
		{
			var userId = User.Identity.GetUserId();

			var courses = unitOfWork.Courses.GetCourses(page, pageSize, query);

			var bookmarks = unitOfWork.Bookmarks.GetUserBookmarks(userId);

			var viewModel = new CoursesViewModel
			{
				Courses = courses,
				Bookmarks = bookmarks.ToLookup(b => b.CourseId),
				ShowActions = User.Identity.IsAuthenticated,
				SearchTerm = query
			};

			return PartialView("_CoursesPartial", viewModel);
		}
	}
}