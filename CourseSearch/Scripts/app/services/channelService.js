var ChannelService = function () {
    var createChannel = function (channelName, channelDescription, done, fail) {
        $.post($('base').attr('href') + "/api/channels/Create", { Name: channelName, Description: channelDescription })
            .done(done)
            .fail(fail);
    };

    var removeChannel = function (channelId, done, fail) {
        $.ajax({
            url: $('base').attr('href') + "/api/channels/Remove/" + channelId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    var addCourseToChannel = function (channelId, courseId, done, fail) {
        $.post($('base').attr('href') + "/api/channels/AddCourse", { ChannelId: channelId, CourseId: courseId })
            .done(done)
            .fail(fail);
    };

    var removeCourseFromChannel = function (channelId, courseId, done, fail) {
        $.ajax({
            url: $('base').attr('href') + "/api/channels/RemoveCourse",
            data: { ChannelId: channelId, CourseId: courseId },
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    return {
        createChannel: createChannel,
        removeChannel: removeChannel,
        addCourseToChannel: addCourseToChannel,
        removeCourseFromChannel: removeCourseFromChannel        
    };
}();