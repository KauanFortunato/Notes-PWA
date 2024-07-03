using Microsoft.JSInterop; // Permite chamadas de funções JavaScript a partir do código C#, e JavaScript para C#
using Notes.Data;
using System.Collections.Generic; // Manipulação e coleção de dados (listas, dicionários, conjuntos, etc.)
using System.Threading.Tasks; // Tarefas Assíncronas

namespace Notes.Pages.Services
{
    /// <summary>
    /// Classe onde fica os métodos de Note, Workspace e LocalStorage
    /// </summary>
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

        public async Task<Note> GetNoteAsync(int id)
        {
            return await _jsRuntime.InvokeAsync<Note>("indexedDBFunctions.getNote");
        }

        public async Task<List<Note>> GetAllNotesAsync()
        {
            return await _jsRuntime.InvokeAsync<List<Note>>("indexedDBFunctions.getAllNotes");
        }

        public async Task DeleteNoteAsync(int id)
        {
            await _jsRuntime.InvokeVoidAsync("indexedDBFunctions.deleteNote", id);
        }

        // Local Storage

        public async Task SetLocalStorageItem(string key, string value)
        {
            await _jsRuntime.InvokeVoidAsync("localStorageFunctions.setItem", key, value);
        }

        public async Task<string> GetLocalStorageItem(string key)
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageFunctions.getItem", key);
        }

        public async Task RemoveLocalStorageItem(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorageFunctions.removeItem", key);
        }

        public async Task ClearLocalStorage()
        {
            await _jsRuntime.InvokeVoidAsync("localStorageFunctions.clearStorage");
        }

        public async Task<string> GetElement(string element)
        {
            string script = $"document.querySelector('{element}').innerText";

            return await _jsRuntime.InvokeAsync<string>("eval", script);
        }
    }
}
