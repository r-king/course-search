var ChannelsController = function (channelService) {
    function init(container) {
        $(container).on("click", "#deleteChannelBtn", deleteChannel);
    }

    var deleteChannel = function (e) {
        var button = $(e.target);

        var channelId = button.attr('data-channel-id');

        channelService.removeChannel(channelId, done, fail);
    }

    var done = function () {
        window.location.href = $('base').attr('href') + "/Channels";
    }

    var fail = function () {
        alert("Failed to delete channel");
    }

    return {
        init: init
    }
}(ChannelService);