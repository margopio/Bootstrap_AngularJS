using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AfterWorkTambayan.Domain.Entities
{
    public class Restaurant
    {
        public Guid RestaurantId { get; set; }
        [Required(ErrorMessage = "Name Not Found")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address Not Found")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City Not Found")]
        public string City { get; set; }        
        [Required(ErrorMessage = "State Not Found")]
        public string State { get; set; }
        [Required(ErrorMessage = "Zip Code Not Found")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Currency Not Found")]
        public string Currency { get; set; }
        [Display(Name = "Tax (%)")]
        public double Tax { get; set; }
        [Display(Name = "Service (%)")]
        public double Service { get; set; }
        public string OperationHrsFrom { get; set; }
        public string OperationHrsTo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int IsTest { get; set; } 
    }
}
