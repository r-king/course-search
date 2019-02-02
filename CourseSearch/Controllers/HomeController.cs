using CourseSearch.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CourseSearch.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext context = new ApplicationDbContext();

		public ActionResult Index()
		{
			IEnumerable<Course> courses =
				context.Courses
				.Include(c => c.Publisher)
				.OrderByDescending(c => c.PublishedOn);

			return View(courses);
		}
	}
}