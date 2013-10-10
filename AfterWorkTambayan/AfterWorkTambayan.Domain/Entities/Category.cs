using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AfterWorkTambayan.Domain.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "ImageUrl Not Found")]
        public string ImageUrl  { get; set; }
        [Required(ErrorMessage = "Name Not Found")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description Not Found")]
        public string Description  { get; set; }
    }
}
