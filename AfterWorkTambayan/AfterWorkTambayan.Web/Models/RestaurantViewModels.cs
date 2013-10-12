using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AfterWorkTambayan.Domain.Entities;
using System.Web.Mvc;

namespace AfterWorkTambayan.Web.Model
{
    public class GetRestaurantViewModel
    {
        public Restaurant Restaurant { get; set; }
        public SelectList USStates { get; set; }
        public SelectList Currencies { get; set; }  
        public bool AMHrs { get; set; }
        public bool PMHrs { get; set; }  
    }

    public class ListRestaurantsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class MenuViewModel
    {        
        public Category Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}