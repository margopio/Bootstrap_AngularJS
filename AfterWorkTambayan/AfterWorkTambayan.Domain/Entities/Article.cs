using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AfterWorkTambayan.Domain.Entities
{
    public class Article
    {
        public Guid ArticleId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string ImageUrl { get; set; }        

        public string ViewCount { get; set; }

        public string AddedBy { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
