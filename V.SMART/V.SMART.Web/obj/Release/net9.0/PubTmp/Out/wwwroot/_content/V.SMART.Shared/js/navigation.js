// ============================================================
// NAVIGATION OUTSIDE CLICK
// ============================================================

window.registerNavOutsideClick = function (dotNetHelper) {

    // Remove previous handler
    window.unregisterNavOutsideClick();

    if (!dotNetHelper) {
        return;
    }

    let isActive = true;

    window.vsNavOutsideClickHandler = function (event) {

        if (!isActive) {
            return;
        }

        // If Blazor circuit is gone, stop handling
        if (!dotNetHelper) {
            isActive = false;
            window.unregisterNavOutsideClick();
            return;
        }

        const target = event.target;

        if (!target) {
            return;
        }

        // Click inside mini navigation item
        const miniItem = target.closest(".vs-mini-item");

        // Click inside flyout
        const flyout = target.closest(".vs-flyout");

        // Don't close when clicking navigation itself
        if (miniItem || flyout) {
            return;
        }

        // Click outside -> close flyout
        dotNetHelper
            .invokeMethodAsync("CloseFlyout")
            .catch(function () {

                // Blazor circuit is disconnected
                isActive = false;

                window.unregisterNavOutsideClick();
            });
    };

    document.addEventListener(
        "click",
        window.vsNavOutsideClickHandler
    );
};


// ============================================================
// UNREGISTER NAVIGATION OUTSIDE CLICK
// ============================================================

window.unregisterNavOutsideClick = function () {

    if (window.vsNavOutsideClickHandler) {

        document.removeEventListener(
            "click",
            window.vsNavOutsideClickHandler
        );

        window.vsNavOutsideClickHandler = null;
    }
};


// ============================================================
// SCROLL HANDLER
// ============================================================

window.registerScrollHandler = function (dotNetHelper) {

    // Remove previous handler
    window.unregisterScrollHandler();

    if (!dotNetHelper) {
        return;
    }

    let isActive = true;

    window.vsScrollHandler = function () {

        if (!isActive) {
            return;
        }

        if (!dotNetHelper) {
            isActive = false;

            window.unregisterScrollHandler();

            return;
        }

        dotNetHelper
            .invokeMethodAsync("OnScroll")
            .catch(function () {

                // Blazor circuit disconnected
                isActive = false;

                window.unregisterScrollHandler();
            });
    };

    window.addEventListener(
        "scroll",
        window.vsScrollHandler,
        {
            passive: true
        }
    );
};


// ============================================================
// UNREGISTER SCROLL HANDLER
// ============================================================

window.unregisterScrollHandler = function () {

    if (window.vsScrollHandler) {

        window.removeEventListener(
            "scroll",
            window.vsScrollHandler
        );

        window.vsScrollHandler = null;
    }
};