using CourseSearch.Core.Repositories;

namespace CourseSearch.Core
{
	public interface IUnitOfWork
	{
		IBookmarkRepository Bookmarks { get; }

		ICourseRepository Courses { get; }

		IPublisherRepository Publishers { get; }

		IChannelRepository Channels { get; }

		IChannelCourseRepository ChannelCourses { get; }

		void Complete();
	}
}