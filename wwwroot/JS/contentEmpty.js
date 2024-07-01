window.detectEmptyClass = {
    observer: null,
    checkClass: function () {
        var editor = document.querySelector('.ql-blank');
        var salvarButton = document.getElementById('salvarButton');

        if (editor != null) {
            salvarButton.disabled = true;
        } else if (salvarButton) {
            salvarButton.disabled = false;
        }
    },

    startObservation: function () {
        var target = document.querySelector('.ql-blank');

        if (!target) {
            target = document.querySelector('.ql-editor');
        }

        observer = new MutationObserver(() => {
            window.detectEmptyClass.checkClass();
        });

        var config = { attributes: true, childList: true, subtree: true, characterData: true };
        observer.observe(target, config);

        window.detectEmptyClass.checkClass();
    },

    stopObservation: function () {
        if (this.observer) {
            this.observer.disconnect();
            this.observer = null;
        }
    }
};
