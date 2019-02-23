using CourseSearch.Core.Repositories;

namespace CourseSearch.Core
{
	public interface IUnitOfWork
	{
		IBookmarkRepository Bookmarks { get; }

		ICourseRepository Courses { get; }

		void Complete();
	}
}