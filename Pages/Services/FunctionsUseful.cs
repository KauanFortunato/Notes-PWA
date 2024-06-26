using Microsoft.JSInterop;
using Notes.Data;

namespace Notes.Pages.Services
{
    public class FunctionsUseful
    {
        private readonly IJSRuntime _jsRuntime;

        public FunctionsUseful(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SetClassItem(string elementId, string classAdd)
        {
            await _jsRuntime.InvokeVoidAsync("functionsUseful.setClassItem", elementId, classAdd);
        }

        public async Task RemoveClassItem(string elementId, string classAdd)
        {
            await _jsRuntime.InvokeVoidAsync("functionsUseful.removeClassItem", elementId, classAdd);
        }
    }
}
