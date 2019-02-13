using CourseSearch.Core.Repositories;

namespace CourseSearch.Core
{
	public interface IUnitOfWork
	{
		IBookmarkRepository Bookmarks { get; }

		void Complete();
	}
}