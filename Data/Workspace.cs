namespace Notes.Data
{
    public class Workspace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreateDate { get; set; }

        public Workspace()
        {
            CreateDate = DateTime.Today.ToString("dd-MM-yyyy");
        }
    }
}