using CourseSearch.Core.Models;
using CourseSearch.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CourseSearch.Persitence.Repositories
{
	public class CourseRepository : ICourseRepository
	{
		private readonly ApplicationDbContext context;

		public CourseRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public IEnumerable<Course> GetBookmarkedCourses(string userId)
		{
			return context.Bookmarks
				.Where(b => b.UserId == userId)
				.Select(b => b.Course)
				.Include(b => b.Publisher);
		}

		public IEnumerable<Course> GetCourses(int page, int pageSize, string query)
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

			return courses;
		}
	}
}