namespace Notes.Data
{
    /// <summary>
    /// Classe responsável por guardar informações das tarefas
    /// </summary>
    public class TaskNote
    {
        public DateTime? DeadLine { get; set; }
        public bool? Done { get; set; } = null;
        public bool Notification { get; set; } = false;
    }
} 
