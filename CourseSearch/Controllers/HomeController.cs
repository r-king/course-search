using CourseSearch.Models;
using CourseSearch.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CourseSearch.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext context = new ApplicationDbContext();

		public ActionResult Index(string query = null)
		{
			IEnumerable<Course> courses =
				context.Courses
				.Include(c => c.Publisher)
				.OrderByDescending(c => c.PublishedOn);

			if (!string.IsNullOrWhiteSpace(query))
			{
				courses = courses.Where(c => c.Title.Contains(query));
			}

			var homeViewModel = new CoursesViewModel
			{
				Courses = courses,
				SearchTerm = query
			};

			return View("Courses", homeViewModel);
		}
	}
}