using Microsoft.JSInterop; // Permite chamadas de funções JavaScript a partir do código C# e vice-versa
using System.Collections.Generic; // Manipulação e coleção de dados (listas, dicionários, conjuntos, etc.)
using System.Threading.Tasks; // Tarefas Assíncronas

namespace Notes.Data
{
    public class NoteService
    {
        private readonly IJSRuntime _jsRuntime;

        public NoteService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task AddNoteAsync(Note note)
        {
            await _jsRuntime.InvokeVoidAsync("indexedDBFunctions.addNote", note);
        }

        public async Task<List<Note>> GetAllNotesAsync()
        {
            return await _jsRuntime.InvokeAsync<List<Note>>("indexedDBFunctions.getAllNotes");
        }

        public async Task DeleteNoteAsync(int id)
        {
            await _jsRuntime.InvokeVoidAsync("indexedDBFunctions.deleteNote", id);
        }
    }
}
