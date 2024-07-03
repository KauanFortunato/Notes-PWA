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

        public int WorkspaceUsedId { get; set; }

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

        /// <summary>
        /// Muda o tipo de agrupamento
        /// </summary>
        /// <param name="tipo">Tipo de agrupamento (data, titulo)</param>
        public async Task ChangeGroupType(string tipo)
        {
            await _noteService.SetLocalStorageItem("orderType", tipo);
            TipoDeAgrupamento = tipo;
        }

        public event Action OnChange;
        private void NotifyDataChanged() => OnChange?.Invoke();
    }
}
