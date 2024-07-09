using Microsoft.JSInterop;
using Notes.Data;

namespace Notes.Pages.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class FunctionsUseful
    {
        private readonly IJSRuntime _jsRuntime;

        public FunctionsUseful(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        /// <summary>
        /// Coloca uma class em um elemento HTML
        /// </summary>
        /// <param name="elementId">Id do elemento a ser colocado a classe</param>
        /// <param name="classAdd">Classe a ser adicionada</param>
        public async Task SetClassItem(string elementId, string classAdd)
        {
            await _jsRuntime.InvokeVoidAsync("functionsUseful.setClassItem", elementId, classAdd);
        }

        /// <summary>
        /// Remove uma class de um elemento HTML
        /// </summary>
        /// <param name="elementId">Id do elemento a ser colocado a classe</param>
        /// <param name="classAdd">Classe a ser adicionada</param>
        public async Task RemoveClassItem(string elementId, string classAdd)
        {
            await _jsRuntime.InvokeVoidAsync("functionsUseful.removeClassItem", elementId, classAdd);
        }

        /// <summary>
        /// Detecta o tipo de dispositivo em que está sendo utilizado
        /// </summary>
        public async Task DetectDevice()
        {
            await _jsRuntime.InvokeVoidAsync("functionsUseful.aplicarEstilos");
        }

        /// <summary>
        /// Função utilizada na barra de pesquisa
        /// </summary>
        public async Task Search(string id)
        {
            await _jsRuntime.InvokeVoidAsync("search", id);
        }

        public async Task SearchWorkspace(string id)
        {
            await _jsRuntime.InvokeVoidAsync("searchWorkspace", id);
        }

        public async Task<bool> IsMobileDevice()
        {
            return await _jsRuntime.InvokeAsync<bool>("functionsUseful.isMobileDevice");
        }

        /// <summary>
        /// Remove as datas do tipo de agrupamento
        /// </summary>
        public async Task RemoveDate()
        {
            await _jsRuntime.InvokeVoidAsync("removeDate");
        }

        /// <summary>
        /// Volta a colocar as datas do tipo de agrupamento
        /// </summary>
        /// <returns></returns>
        public async Task AddDate()
        {
            await _jsRuntime.InvokeVoidAsync("addDate");
        }

        public async Task SidebarActive()
        {
            await _jsRuntime.InvokeVoidAsync("functionsUseful.sidebarActive");
        }

        public async Task SidebarClose()
        {
            await _jsRuntime.InvokeVoidAsync("functionsUseful.sidebarClose");
        }
    }
}
