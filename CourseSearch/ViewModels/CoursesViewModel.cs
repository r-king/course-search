using CourseSearch.Models;
using System.Collections.Generic;

namespace CourseSearch.ViewModels
{
	public class CoursesViewModel
	{
		public IEnumerable<Course> Courses { get; set; }
		public string SearchTerm { get; set; }
	}
}