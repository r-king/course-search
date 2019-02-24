using CourseSearch.Core.Models;
using CourseSearch.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CourseSearch.Persitence.Repositories
{
	public class ChannelCourseRepository : IChannelCourseRepository
	{
		private readonly ApplicationDbContext context;

		public ChannelCourseRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public void AddCourseToChannel(ChannelCourse channelCourse)
		{
			context.ChannelCourses.Add(channelCourse);
		}

		public ChannelCourse GetChannelCourse(int channelId, int courseId)
		{
			return context.ChannelCourses
				.FirstOrDefault(c => c.ChannelId == channelId && c.CourseId == courseId);
		}

		public IEnumerable<ChannelCourse> GetChannelCourses(int channelId)
		{
			return context.ChannelCourses.Where(c => c.ChannelId == channelId);
		}

		public void RemoveCourseFromChannel(ChannelCourse channelCourse)
		{
			context.ChannelCourses.Remove(channelCourse);
		}
	}
}