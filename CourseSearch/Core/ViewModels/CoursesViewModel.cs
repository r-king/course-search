using CourseSearch.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace CourseSearch.Core.ViewModels
{
	public class CoursesViewModel
	{
		public IEnumerable<Course> Courses { get; set; }
		public string SearchTerm { get; set; }
		public bool ShowActions { get; set; }
		public ILookup<int, Bookmark> Bookmarks { get; set; }
	}
}