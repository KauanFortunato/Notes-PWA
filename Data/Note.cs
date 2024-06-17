﻿namespace Notes.Data
{
    public class Note
    {
        private DateTime today;
        private string createDate;

        public Note()
        {
            today = DateTime.Today;
            createDate = today.ToString("dd-MM-yyyy");
        }

        public int Id { get; set; }
        public int WorkSpaceId {  get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
    }
}
