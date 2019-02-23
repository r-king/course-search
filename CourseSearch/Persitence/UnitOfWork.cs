using CourseSearch.Core;
using CourseSearch.Core.Repositories;
using CourseSearch.Persitence.Repositories;

namespace CourseSearch.Persitence
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext context;

		public IBookmarkRepository Bookmarks { get; private set; }

		public ICourseRepository Courses { get; private set; }

		public UnitOfWork(ApplicationDbContext context)
		{
			this.context = context;

			Bookmarks = new BookmarkRepository(context);
			Courses = new CourseRepository(context);
		}

		public void Complete()
		{
			context.SaveChanges();
		}
	}
}