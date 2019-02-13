var CoursesController = function (bookmarkService) {
    var image;

    function init(container) {
        $(container).on("click", ".js-toggle-bookmark", toggleBookmark);
    }

    var toggleBookmark = function (e) {
        image = $(e.target);
       
        var courseId = image.attr("data-course-id");

        if (image.hasClass("far fa-bookmark fa-lg"))
            bookmarkService.addBookmark(courseId, done, fail);
        else
            bookmarkService.removeBookmark(courseId, done, fail);
    }

    var done = function () {
        image.toggleClass("fas fa-bookmark fa-lg").toggleClass("far fa-bookmark fa-lg");
    }

    var fail = function () {
        alert("Unable to bookmark course");
    }

    return {
        init: init
    }

}(BookmarkService);