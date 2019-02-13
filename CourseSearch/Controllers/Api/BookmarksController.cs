using CourseSearch.Core;
using CourseSearch.Core.Dtos;
using CourseSearch.Core.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace CourseSearch.Controllers.Api
{
	[Authorize]
	public class BookmarksController : ApiController
	{
		private readonly IUnitOfWork unitOfWork;

		public BookmarksController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		[HttpPost]
		public IHttpActionResult AddBookmark(BookmarkDto dto)
		{
			var userId = User.Identity.GetUserId();

			if (unitOfWork.Bookmarks.GetBookmark(userId, dto.CourseId) != null)
				return BadRequest("Cousrse already bookmarked by user");

			var bookmark = new Bookmark
			{
				UserId = userId,
				CourseId = dto.CourseId
			};

			unitOfWork.Bookmarks.AddBookmark(bookmark);

			unitOfWork.Complete();

			return Ok();
		}

		[HttpDelete]
		public IHttpActionResult RemoveBookmark(int id)
		{
			var userId = User.Identity.GetUserId();

			var bookmark = unitOfWork.Bookmarks.GetBookmark(userId, id);

			if (bookmark == null)
				return NotFound();

			unitOfWork.Bookmarks.RemoveBookmark(bookmark);

			unitOfWork.Complete();

			return Ok(id);
		}
	}
}