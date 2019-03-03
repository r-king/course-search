var CoursesController = function (bookmarkService, channelService) {
    var image;
    var ul;
    var a;
    var channelCheckBox;

    function init(container) {
        $(container).on("click", ".js-toggle-bookmark", toggleBookmark);
        $(container).on("click", ".js-toggle-channels", getChannels);
    }

    var toggleBookmark = function (e) {
        image = $(e.target);

        var courseId = image.attr("data-course-id");

        if (image.hasClass("far fa-bookmark fa-lg"))
            bookmarkService.addBookmark(courseId, done, fail);
        else
            bookmarkService.removeBookmark(courseId, done, fail);
    }

    var getChannels = function (e) {
        a = $(e.target);
        var courseId = a.attr("data-course-id");

        $.getJSON($('base').attr('href') + "/api/channels/GetUserChannelsForCourse/" + courseId, function (channels) {
            // ul list holding channels in drop down
            ul = $(a).closest('li').find('.dropdown-menu');

            // prevent drop down list from closing
            $(ul).on('click', null, function (e) {
                e.stopPropagation();
            });

            var channelListHtml = "";
            $.each(channels, function (i, channel) {
                channelListHtml += "<li class=\"dropdown-item\"><input class=\"channel-checkbox\" " + (channel.Selected ? "checked" : "") + " data-course-id=\"" + courseId + "\" data-channel-id=\"" + channel.Id + "\" type=\"checkbox\">" + channel.Name + "</li>";
            })
            // populate channel drop down list
            ul.html(channelListHtml);
            $(ul).on('change', 'input[type=checkbox]', function () {
                channelCheckBox = $(this)[0];

                var courseId = $(channelCheckBox).attr("data-course-id");
                var channelId = $(channelCheckBox).attr("data-channel-id");
                console.log(courseId);
                console.log(channelId);
                if (channelCheckBox.checked) {
                    channelService.addCourseToChannel(channelId, courseId);
                } else {
                    channelService.removeCourseFromChannel(channelId, courseId);
                }
            });
        })
    }

    //channelService.getUserChannelsForCourse(courseId, ul);

    var done = function () {
        image.toggleClass("fas fa-bookmark fa-lg").toggleClass("far fa-bookmark fa-lg");
    }

    var fail = function () {
        alert("Unable to bookmark course");
    }

    return {
        init: init
    }
}(BookmarkService, ChannelService);