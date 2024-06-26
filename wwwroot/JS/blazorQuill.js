(function () {
    window.QuillFunctions = {
        createQuill: function (quillElement, type) {
            if (type) {
                var options = {
                    
                    placeholder: 'Digite aqui',
                    readOnly: type,
                };
            } else {
                var options = {
                    
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
        },

        elementExist: function () {
            try {
                const divEditorElement = document.getElementById("divEditorElement");

                if (!divEditorElement) {
                    console.log("Elemento não Existe");
                    return false;
                }

                const elements = divEditorElement.getElementsByClassName("ql-blank");

                if (elements.length > 0) {
                    console.log("Elemento Existe");
                    return true;
                } else {
                    console.log("Elemento não Existe");
                    return false;
                }
            } catch (error) {
                console.log("Elemento não Existe");
                return false;
            }
        }
    };
})();

