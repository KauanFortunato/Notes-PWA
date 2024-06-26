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
    }
}