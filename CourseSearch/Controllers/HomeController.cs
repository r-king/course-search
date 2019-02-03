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
			IEnumerable<Course> courses;

			if (!string.IsNullOrWhiteSpace(query))
			{
				courses = context.Courses
				   .Where(c => c.Title.Contains(query))
				   .Take(pageSize)
				   .Include(c => c.Publisher)
				   .OrderByDescending(c => c.PublishedOn);
			}
			else
			{
				courses = context.Courses
				   .Take(pageSize)
				   .Include(c => c.Publisher)
				   .OrderByDescending(c => c.PublishedOn);
			}

			var homeViewModel = new CoursesViewModel
			{
				Courses = courses,
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
			IEnumerable<Course> courses;

			if (!string.IsNullOrWhiteSpace(query))
			{
				courses = context.Courses
					.Where(c => c.Title.Contains(query))
					.Include(c => c.Publisher)
					.OrderByDescending(c => c.PublishedOn)
					.Skip(page * pageSize)
					.Take(pageSize);
			}
			else
			{
				courses = context.Courses
					.Include(c => c.Publisher)
					.OrderByDescending(c => c.PublishedOn)
					.Skip(page * pageSize)
					.Take(pageSize);
			}

			return PartialView("_CoursesPartial", courses);
		}
	}
}