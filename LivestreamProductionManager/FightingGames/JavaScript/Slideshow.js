function initSlideshow(slideshowContainerSelector, inClass, outClass, transitionDurationInMilliSeconds, intervalInMilliSeconds, amountOfSlides) {
    $(`${ slideshowContainerSelector } > div:gt(0)`).addClass(outClass);
    $(`${ slideshowContainerSelector } > div:first`).addClass(inClass);

    if (transitionDurationInMilliSeconds !== null) {
        $(`${ slideshowContainerSelector } > div`).each(function () {
            $(this).css("animation-duration", transitionDurationInMilliSeconds);
            $(this).css("transition-duration", transitionDurationInMilliSeconds);
        });
    }

    setInterval(function () {
        if ($(`${slideshowContainerSelector} > div.${ inClass }:first`).is($(`${slideshowContainerSelector} > div:last-child`))) {
            $(`${slideshowContainerSelector} > div.${ inClass }:first`).removeClass(inClass).addClass(outClass);
            $(`${slideshowContainerSelector} > div:first`).removeClass(outClass).addClass(inClass);
        } else {
            $(`${slideshowContainerSelector} > div.${ inClass }:first`).removeClass(inClass).addClass(outClass).addClass(outClass)
                .next().removeClass(outClass).addClass(inClass);
        }
    }, intervalInMilliSeconds);
}