using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AfterWorkTambayan.Domain.Entities;

namespace AfterWorkTambayan.Domain.Repository
{    
    public interface IRestaurantRepository
    {
        bool Add(Restaurant restaurant);
        bool Delete(Guid id);
        Restaurant GetRestaurant(Guid id);
        IEnumerable<Restaurant> GetRestaurants();
        void ClearAll();        
    }
}
