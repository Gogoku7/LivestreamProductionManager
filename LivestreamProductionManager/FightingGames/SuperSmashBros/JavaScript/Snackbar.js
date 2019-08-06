function showSnackbar(message) {
    try {
        if ($("#snackbar").length) {
            $("#snackbar").html(message);

            var marginLeft = ($(window).width() - $("#snackbar").outerWidth()) / 2;
            $("#snackbar").css("left", marginLeft >= 0 ? marginLeft : 0);

            $("#snackbar").addClass("show");

            setTimeout(function () {
                $("#snackbar").removeClass("show");
            }, 9000);
        } else {
            console.log("#snackbar element is not present to display a message in.");
            console.log(message);
        }
    } catch (ex) {
        console.log(ex);
    }
}