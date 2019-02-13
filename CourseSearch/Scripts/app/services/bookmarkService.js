var BookmarkService = function () {
    var addBookmark = function (courseId, done, fail) {
        $.post("api/bookmarks", { CourseId: courseId })
            .done(done)
            .fail(fail);
    }

    var removeBookmark = function (courseId, done, fail) {
        $.ajax({
            url: "api/bookmarks/" + courseId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    }

    return {
        addBookmark: addBookmark,
        removeBookmark: removeBookmark
    }
}();