using CourseSearch.Core.ViewModels;
using System.Web.Mvc;

namespace CourseSearch.Controllers
{
	public class CoursesController : Controller
	{
		[HttpPost]
		public ActionResult Search(CoursesViewModel viewModel)
		{
			return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
		}
	}
}