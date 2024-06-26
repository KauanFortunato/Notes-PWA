window.localStorageFunctions = {
    setItem: function (key, value) {
        localStorage.setItem(key, value);
    },

    getItem: function (key) {
        var item = localStorage.getItem(key);
        return item;
    },

    removeItem: function (key) {
        localStorage.removeItem(key);
    },

    clearStorage: function () {
        localStorage.clear();
    }
}

if (!localStorage.getItem("orderType")) {
    localStorageFunctions.setItem("orderType", "data");
}
if (!localStorage.getItem("visualization")) {
    localStorageFunctions.setItem("visualization", "grid")
}