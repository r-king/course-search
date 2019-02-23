using CourseSearch.Core.Models;
using System.Collections.Generic;

namespace CourseSearch.Core.Repositories
{
	public interface ICourseRepository
	{
		IEnumerable<Course> GetCourses(int page, int pageSize, string query);

		IEnumerable<Course> GetBookmarkedCourses(string userId);

		IEnumerable<Course> GetPublisherCourses(int publisherId);		
	}
}