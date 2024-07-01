using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;

namespace Notes.Pages.Services
{
    public class QuillService
    {
        private readonly IJSRuntime _jsRuntime;

        public QuillService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task CreateQuill(ElementReference divEditorElement, bool type = false)
        {
            await _jsRuntime.InvokeAsync<string>(
                "QuillFunctions.createQuill", divEditorElement, type);
        }

        public async Task<string> GetText(ElementReference divEditorElement)
        {
            return await _jsRuntime.InvokeAsync<string>(
            "QuillFunctions.getQuillText", divEditorElement);
        }

        public async Task<string> GetHTML(ElementReference divEditorElement)
        {
            return await _jsRuntime.InvokeAsync<string>(
                "QuillFunctions.getQuillHTML", divEditorElement);
        }

        public async Task<string> GetEditorContent(ElementReference divEditorElement)
        {
            return await _jsRuntime.InvokeAsync<string>(
                "QuillFunctions.getQuillContent", divEditorElement);
        }

        public async Task<string> SaveContent(ElementReference divEditorElement)
        {
            return await _jsRuntime.InvokeAsync<string>(
                "QuillFunctions.getQuillContent", divEditorElement);
        }

        public async Task<object> LoadContent(ElementReference divEditorElement, string strSavedContent)
        {
            return await _jsRuntime.InvokeAsync<object>(
                "QuillFunctions.loadQuillContent", divEditorElement, strSavedContent);
        }

        public async Task DisableQuillEditor(ElementReference divEditorElement)
        {
            await _jsRuntime.InvokeAsync<object>(
                "QuillFunctions.disableQuillEditor", divEditorElement);
        }

        public async Task StartObservation()
        {
            await _jsRuntime.InvokeVoidAsync("detectEmptyClass.startObservation");
        }

        public async Task StopObservation()
        {
            await _jsRuntime.InvokeVoidAsync("detectEmptyClass.stopObservation");
        }
    }
}
