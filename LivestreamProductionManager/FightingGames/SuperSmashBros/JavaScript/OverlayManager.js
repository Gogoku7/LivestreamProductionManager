var FittyElements = [];
var OverlayType = "";

function initWebSocketAndFitty(fittyElements, overlayType) {
    try {
        $.each(fittyElements, function (i) {
            fitty(fittyElements[i].selector, { minSize: fittyElements[i].minSize, maxSize: fittyElements[i].maxSize, multiLine: fittyElements[i].multiLine });
        });

        FittyElements = fittyElements;
        OverlayType = overlayType;

        // Use ws://localhost:56613/WebSocket/Queu by default
        // Use ws://localhost/livestreamproductionmanager/WebSocket/Queu when the application is deployed to IIS and running on http://localhost/livestreamproductionmanager
        // Use ws://localhost/WebSocket/Queu when the application is deployed to IIS and running on http://localhost
        // Replace ws:// by wws:// when using HTTPS
        var uri = "ws://localhost:56613/WebSocket/Queu";

        websocket = new WebSocket(uri);

        websocket.onopen = function () {
            console.log("Connected to server.");
            var jsonData = { "type": "overlayConnected", "overlayType": OverlayType, "data": window.location.href };
            websocket.send(JSON.stringify(jsonData));
        };

        websocket.onerror = function (event) {
            showSnackbar("Something went wrong with the connection to the Queu WebSocket to receive live updates. If Livestream Production Manager is deployed to IIS, make sure there's no port like ':56613' defined after 'localhost' in the uri variable of OverlayManager.js and IIS has WebSockets enabled.");

            console.log("Something went wrong with the connection to the Queu WebSocket to receive live updates. If Livestream Production Manager is deployed to IIS, make sure there's no port like ':56613' defined after 'localhost' in the uri variable of OverlayManager.js and IIS has WebSockets enabled.");
            console.log("When using Livestream Production Manager deployed to IIS, also check if the 'BaseUrl' AppSetting in Web.config also has no port like ':56613' either.");
            console.log(event);
        };

        websocket.onmessage = function (event) {
            console.log(event.data);

            var jsonData = JSON.parse(event.data);

            if (jsonData.type == "queu") {
                $.each(jsonData.data, function (i) {
                    if ($(jsonData.data[i]).hasClass("specialFade")) {
                        $(jsonData.data[i]).addClass("changing-visbility");
                    } else {
                        $(jsonData.data[i]).addClass("changing");
                    }
                });

                setTimeout(function () {
                    $('link[rel="stylesheet"]').not('link[href="css/styles.css"]').not('link[href="../../CSS/Queu.css"]').not().each(function () {
                        this.href = this.href.replace(/\?.*|$/, "?reload=" + new Date().getTime());
                    });

                    setTimeout(function () {
                        $.each(jsonData.data, function (i) {
                            $.each(FittyElements, function (j) {
                                if (FittyElements[j].selector.startsWith(".")) {
                                    if ($(jsonData.data[i]).hasClass(FittyElements[j].selector.replace(/\./g, ''))) {
                                        fitty(FittyElements[j].selector, { minSize: FittyElements[j].minSize, maxSize: FittyElements[j].maxSize, multiLine: FittyElements[j].multiLine });
                                    }
                                }

                                if (FittyElements[j].selector.startsWith("#")) {
                                    if ($(jsonData.data[i]).is(FittyElements[j].selector)) {
                                        fitty(FittyElements[j].selector, { minSize: FittyElements[j].minSize, maxSize: FittyElements[j].maxSize, multiLine: FittyElements[j].multiLine });
                                    }
                                }
                            });

                            $.each(jsonData.data, function (i) {
                                if ($(jsonData.data[i]).hasClass("specialFade")) {
                                    $(jsonData.data[i]).removeClass("changing-visbility").addClass("changed-visbility");
                                } else {
                                    $(jsonData.data[i]).removeClass("changing").addClass("changed");
                                }
                            });
                        });
                    }, 500);

                    setTimeout(function () {
                        $.each(jsonData.data, function (i) {
                            if ($(jsonData.data[i]).hasClass("specialFade")) {
                                $(jsonData.data[i]).removeClass("changing-visbility").addClass("changed-visbility");
                            } else {
                                $(jsonData.data[i]).removeClass("changed");
                            }
                        });
                    }, 500);
                }, 500);
            }
            else if (jsonData.type == "forceResize") {
                $.each(FittyElements, function (i) {
                    $(FittyElements[i].selector).addClass("changing");
                });

                setTimeout(function () {
                    $.each(FittyElements, function (i) {
                        fitty(FittyElements[i].selector, { minSize: FittyElements[i].minSize, maxSize: FittyElements[i].maxSize, multiLine: FittyElements[i].multiLine });
                    });

                    $.each(FittyElements, function (i) {
                        $(FittyElements[i].selector).removeClass("changing").addClass("changed");
                    });

                    setTimeout(function () {
                        $.each(FittyElements, function (i) {
                            $(FittyElements[i].selector).removeClass("changed");
                        });
                    }, 500);
                }, 500);
            }
        };
    } catch (ex) {
        console.log(ex);
    }
}

$(window).on("beforeunload", function () {
    try {
        var jsonData = { "type": "overlayDisconnected", "overlayType": OverlayType, "data": window.location.href };
        websocket.send(JSON.stringify(jsonData));
        websocket.close();
    } catch (ex) {
        console.log(ex);
    }
});