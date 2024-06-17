namespace Notes.Data
{
    public class Workspaces
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreateDate { get; set; }

        public Workspaces()
        {
            CreateDate = DateTime.Today.ToString("dd-MM-yyyy");
        }
    }
}