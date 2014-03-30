using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AfterWorkTambayan.Domain.Entities
{
    public class Article
    {
        public Guid ArticleId { get; set; }
        [Display(Name = "Title*:")]
        [Required(ErrorMessage = "You can't leave this empty.")]
        public string Title { get; set; }
        
        [Display(Name = "Body:")]
        [Required(ErrorMessage = "You can't leave this empty.")]
        public string Body { get; set; }
        
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "You can't leave this empty.")]
        public string Caption { get; set; }   

        public string ViewCount { get; set; }
        [Display(Name = "Written by:")]
        [Required(ErrorMessage = "You can't leave this empty.")]
        public string AddedBy { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
