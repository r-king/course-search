using CourseSearch.Core.Models;
using System.Collections.Generic;

namespace CourseSearch.Core.Repositories
{
	public interface IBookmarkRepository
	{
		void AddBookmark(Bookmark bookmark);

		void RemoveBookmark(Bookmark bookmark);

		IEnumerable<Bookmark> GetUserBookmarks(string userId);

		Bookmark GetBookmark(string userId, int courseId);
	}
}