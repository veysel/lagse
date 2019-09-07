using System;

namespace Lagse.Model.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public string AuthorName { get; set; }
        public DateTime RecordDate { get; set; }
        public bool IsActive { get; set; }
    }
}