var BookmarkService = function () {

    var addBookmark = function (courseId, done, fail) {        
        $.post($('base').attr('href') + "/api/bookmarks", { CourseId: courseId })
            .done(done)
            .fail(fail);
    }

    var removeBookmark = function (courseId, done, fail) {
        $.ajax({
            url: $('base').attr('href') + "/api/bookmarks/" + courseId,
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