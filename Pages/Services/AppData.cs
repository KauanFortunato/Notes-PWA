using System;
using System.Threading.Tasks;

namespace Notes.Pages.Services
{
    public class AppData
    {
        private string _tipoDeAgrupamento;
        private readonly NoteService _noteService;
        public AppData(NoteService noteService)
        {
            _noteService = noteService;
        }

        public string TipoDeAgrupamento
        {
            get
            {
                return _tipoDeAgrupamento;
            }

            set
            {
                _tipoDeAgrupamento = value;
                NotifyDataChanged();
            }
        }

        public async Task MudarTipoDeAgrupamento(string tipo)
        {
            await _noteService.SetLocalStorageItem("orderType", tipo);
            TipoDeAgrupamento = tipo;
        }

        public event Action OnChange;
        private void NotifyDataChanged() => OnChange?.Invoke();
    }
}
