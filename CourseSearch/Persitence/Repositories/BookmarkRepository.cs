using CourseSearch.Core.Models;
using CourseSearch.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CourseSearch.Persitence.Repositories
{
	public class BookmarkRepository : IBookmarkRepository
	{
		private readonly ApplicationDbContext context;

		public BookmarkRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public void AddBookmark(Bookmark bookmark)
		{
			context.Bookmarks.Add(bookmark);
		}

		public Bookmark GetBookmark(string userId, int courseId)
		{
			return context.Bookmarks
				.SingleOrDefault(b => b.UserId == userId && b.CourseId == courseId);
		}

		public IEnumerable<Bookmark> GetUserBookmarks(string userId)
		{
			return context.Bookmarks.Where(b => b.UserId == userId);
		}

		public void RemoveBookmark(Bookmark bookmark)
		{
			context.Bookmarks.Remove(bookmark);
		}
	}
}