namespace Notes.Data
{
    /// <summary>
    /// Classe responsável por guardar as informações das notas 
    /// </summary>
    public class Note
    {
        private DateTime today;
        private string createDate;
        private bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        public Note()
        {
            today = DateTime.Today;
            createDate = today.ToString("dd-MM-yyyy");
        }

        public int Id { get; set; }
        public int WorkspaceId {  get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public TaskNote Task { get; set; }
        public string CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

        /// <summary>
        /// Método que retorna o valor da variável createDateDatetime convertendo para DateTime
        /// </summary>
        /// <returns></returns>
        public DateTime CreateDateDateTime()
        {
            DateTime createDateDateTime = Convert.ToDateTime(createDate);
            return createDateDateTime;
        }
    }
}
