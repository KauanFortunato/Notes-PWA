window.functionsUseful = {
    setClassItem: function (elementId, classAdd) {
        var elements = document.getElementsByClassName(elementId);

        for (var i = 0; i < elements.length; i++) {
            elements[i].classList.add(classAdd);
        }
    },

    removeClassItem: function (elementId, classAdd) {
        var elements = document.getElementsByClassName(elementId);

        for (var i = 0; i < elements.length; i++) {
            elements[i].classList.remove(classAdd);
        }
    },

    sidebarActive: function () {
        functionsUseful.setClassItem("side-bar-container", "active");
    },

    sidebarClose: function () {
        functionsUseful.removeClassItem("side-bar-container", "active");
    },

    isMobileDevice: function () {
        return /Mobi|Android/i.test(navigator.userAgent);
    },

    aplicarEstilos: function () {
        var body = document.body;
        if (functionsUseful.isMobileDevice()) {
            body.classList.add('mobile-device');
            console.log("Is mobile");
        } else {
            console.log("Not is mobile");
            body.classList.remove('mobile-device');
        }
    }
}