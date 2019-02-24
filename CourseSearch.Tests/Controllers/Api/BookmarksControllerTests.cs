using CourseSearch.Controllers.Api;
using CourseSearch.Core;
using CourseSearch.Core.Dtos;
using CourseSearch.Core.Models;
using CourseSearch.Core.Repositories;
using CourseSearch.Tests.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace CourseSearch.Tests.Controllers.Api
{
	[TestClass]
	public class BookmarksControllerTests
	{
		private string userId = "1";
		private BookmarksController controller;
		private Mock<IBookmarkRepository> repository;

		[TestInitialize]
		public void TestInitialize()
		{
			repository = new Mock<IBookmarkRepository>();

			var mockUoW = new Mock<IUnitOfWork>();
			mockUoW.Setup(u => u.Bookmarks).Returns(repository.Object);

			controller = new BookmarksController(mockUoW.Object);

			controller.MockCurrentUser(userId, "user1@domian.com");
		}

		[TestMethod]
		public void BookmarkCourse_BookmarkAlreadyExists_ShouldReturnBadRequest()
		{
			Bookmark bookmark = new Bookmark { UserId = userId, CourseId = 1 };

			repository.Setup(b => b.GetBookmark(userId, 1)).Returns(bookmark);

			var result = controller.AddBookmark(new BookmarkDto { CourseId = 1 });

			result.Should().BeOfType<BadRequestErrorMessageResult>();
		}

		[TestMethod]
		public void BookmarkCourse_ValidRequest_ShouldReturnOk()
		{
			Bookmark bookmark = new Bookmark { UserId = userId, CourseId = 1 };

			repository.Setup(b => b.GetBookmark(userId, 1)).Returns(bookmark);

			var result = controller.AddBookmark(new BookmarkDto { CourseId = 2 });

			result.Should().BeOfType<OkResult>();
		}

		[TestMethod]
		public void RemoveBookmark_NoBookmarkWithGivenIdExists_ShouldReturnNotFound()
		{
			Bookmark bookmark = null;

			repository.Setup(b => b.GetBookmark(userId, 1)).Returns(bookmark);

			var result = controller.RemoveBookmark(1);

			result.Should().BeOfType<NotFoundResult>();
		}

		[TestMethod]
		public void RemoveBookmark_ValidRequest_ShouldReturnTheCourseIdOfDeletedBookmark()
		{
			Bookmark bookmark = new Bookmark { UserId = userId, CourseId = 1 };

			repository.Setup(b => b.GetBookmark(userId, 1)).Returns(bookmark);

			var result = (OkNegotiatedContentResult<int>)controller.RemoveBookmark(1);

			result.Content.Should().Be(1);
		}
	}
}