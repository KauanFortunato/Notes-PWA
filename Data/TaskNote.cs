namespace Notes.Data
{
    public class TaskNote
    {
        public int Id { get; set; }
        public DateTime? DeadLine { get; set; }
        public bool Done { get; set; } = false;
    }
}
