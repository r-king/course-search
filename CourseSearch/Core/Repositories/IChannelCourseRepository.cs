using CourseSearch.Core.Models;
using System.Collections.Generic;

namespace CourseSearch.Core.Repositories
{
	public interface IChannelCourseRepository
	{
		void AddCourseToChannel(ChannelCourse channelCourse);

		void RemoveCourseFromChannel(ChannelCourse channelCourse);

		IEnumerable<Course> GetCourses(int channelId);

		ChannelCourse GetChannelCourse(int channelId, int courseId);

		IEnumerable<ChannelCourse> GetChannelCourses(int channelId);
	}
}