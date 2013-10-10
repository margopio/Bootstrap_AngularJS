using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AfterWorkTambayan.Domain.Entities;

namespace AfterWorkTambayan.Domain.Repository
{    
    public class RestaurantRepository : IRestaurantRepository
    {
        private InMemoryRestaurant _instance;

        public RestaurantRepository()
        {
            _instance = InMemoryRestaurant.GetInstance();
        }
        
        public bool Add(Restaurant restaurant)
        {
            var flag = false;
            try
            {
                _instance.Add(restaurant);
                flag = true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;                
            }
            return flag;
        }

        public bool Delete(Guid id)
        {
            var flag = false;
            try
            {
                var restaurant = _instance.Restaurants.FirstOrDefault(r => r.RestaurantId == id);
                if (restaurant != null)
                {
                    _instance.Remove(restaurant);
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;                
            }
            return flag;
        }

        public Restaurant GetRestaurant(Guid id)
        {
            var restaurant = _instance.Restaurants.FirstOrDefault(r => r.RestaurantId == id);
            return restaurant;
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _instance.Restaurants;            
        }

        public void ClearAll()
        {
            _instance.ClearAll();
        }
    }
}
