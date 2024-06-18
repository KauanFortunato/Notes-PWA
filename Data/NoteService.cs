using Microsoft.JSInterop; // Permite chamadas de funções JavaScript a partir do código C#, e JavaScript para C#
using System.Collections.Generic; // Manipulação e coleção de dados (listas, dicionários, conjuntos, etc.)
using System.Threading.Tasks; // Tarefas Assíncronas

namespace Notes.Data
{
    public class NoteService
    {
        private readonly IJSRuntime _jsRuntime;

        // CRUD Notes

        public NoteService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task AddNoteAsync(Note note)
        {
            await _jsRuntime.InvokeVoidAsync("indexedDBFunctions.addNote", note);
        }

        public async Task UpdateNoteAsync(Note note)
        {
            await _jsRuntime.InvokeVoidAsync("indexedDBFunctions.updateNote", note);
        }

        public async Task<List<Note>> GetAllNotesAsync()
        {
            return await _jsRuntime.InvokeAsync<List<Note>>("indexedDBFunctions.getAllNotes");
        }

        public async Task DeleteNoteAsync(int id)
        {
            await _jsRuntime.InvokeVoidAsync("indexedDBFunctions.deleteNote", id);
        }

        // CRUD Workspaces

        public async Task AddWorkspace(Workspace workspace)
        {
            await _jsRuntime.InvokeVoidAsync("indexedDBFunctions.addWorkspace", workspace);
        }

        public async Task UpdateWorkspace(Workspace workspace)
        {
            await _jsRuntime.InvokeVoidAsync("indexedDBFunctions.updateWorkspace", workspace);
        }

        public async Task DeleteWorkspace(int id)
        {
            await _jsRuntime.InvokeVoidAsync("indexedDBFunctions.deleteWorkspace", id);
        }

        public async Task<List<Workspace>> GetAllWorkspaces()
        {
            return await _jsRuntime.InvokeAsync<List<Workspace>>("indexedDBFunctions.getAllWorkspaces");
        }

    }
}
