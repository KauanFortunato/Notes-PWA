(function () {
    window.QuillFunctions = {
        createQuill: function (quillElement, type) {
            if (type) {
                var options = {
                    debug: 'info',
                    placeholder: 'Digite aqui',
                    readOnly: type,
                };
            } else {
                var options = {
                    debug: 'info',
                    modules: {
                        toolbar: '#toolbar'
                    },
                    placeholder: 'Digite aqui',
                    readOnly: type,
                    theme: 'snow'
                };
            }
            
            new Quill(quillElement, options);
        },

        getQuillContent: function (quillControl) {
            return JSON.stringify(quillControl.__quill.getContents());
        },
        getQuillText: function (quillControl) {
            return quillControl.__quill.getText();
        },
        getQuillHTML: function (quillControl) {
            return quillControl.__quill.root.innerHTML;
        },

        loadQuillContent: function (quillControl, quillContent) {
            content = JSON.parse(quillContent);
            return quillControl.__quill.setContents(content, 'api');
        },

        disableQuillEditor: function (quillControl) {
            quillControl.__quill.enable(false);
        }
    };
})();

document.addEventListener('DOMContentLoaded', (event) => {
    const element = document.getElementById('toolbar');
    if (element) {
        QuillFunctions.createQuill(element);
    }
});