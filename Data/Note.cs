﻿namespace Notes.Data
{
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
        public DateTime CreateDateDateTime()
        {
            DateTime createDateDateTime = Convert.ToDateTime(createDate);
            return createDateDateTime;
        }
    }
}
