$(document).ready(function () {
    let notificationCount = 3;
    let messageCount = 2;

    if (notificationCount === 0) $("#notificationCount").hide();
    else $("#notificationCount").text(notificationCount);

    if (messageCount === 0) $("#messageCount").hide();
    else $("#messageCount").text(messageCount);
});