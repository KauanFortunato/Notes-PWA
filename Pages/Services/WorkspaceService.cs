using Microsoft.JSInterop;
using Notes.Data;

namespace Notes.Pages.Services
{
    public class WorkspaceService
    {
        private readonly IJSRuntime _jsRuntime;

        public WorkspaceService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task AddWorkspaceAsync(Workspace workspace)
        {
            await _jsRuntime.InvokeVoidAsync("indexedDBFunctions.addWorkspace", workspace);
        }

        public async Task UpdateWorkspaceAsync(Workspace workspace)
        {
            await _jsRuntime.InvokeVoidAsync("indexedDBFunctions.updateWorkspace", workspace);
        }

        public async Task DeleteWorkspaceAsync(int id)
        {
            await _jsRuntime.InvokeVoidAsync("indexedDBFunctions.deleteWorkspace", id);
        }

        public async Task<List<Workspace>> GetAllWorkspacesAsync()
        {
            return await _jsRuntime.InvokeAsync<List<Workspace>>("indexedDBFunctions.getAllWorkspaces");
        }

        public async Task<Workspace> GetWorkspaceAsync(int id)
        {
            return await _jsRuntime.InvokeAsync<Workspace>("indexedDBFunctions.getWorkspace", id);
        }
    }
}
