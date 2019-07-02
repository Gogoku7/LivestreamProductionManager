function showSnackbar(message) {
    try {
        $("#snackbar").html(message);

        var marginLeft = ($(window).width() - $("#snackbar").outerWidth()) / 2;
        $("#snackbar").css("left", marginLeft >= 0 ? marginLeft : 0);

        $("#snackbar").addClass("show");
        setTimeout(function () {
            $("#snackbar").removeClass("show");
        }, 9000);
    } catch (ex) {
        console.log(ex);
    }
}