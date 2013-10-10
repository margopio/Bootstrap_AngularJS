using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AfterWorkTambayan.Domain.Entities;

namespace AfterWorkTambayan.Domain.Repository
{
    public class InMemoryRestaurant
    {
        private static List<Restaurant> _restaurants;        
        private static InMemoryRestaurant _instance = null;
        private static readonly object Lock = new object();

        private InMemoryRestaurant()
        {
            _restaurants = new List<Restaurant>();            
        }

        public static InMemoryRestaurant GetInstance()
        {
            if (_instance == null)
            {
                _instance = new InMemoryRestaurant();
            }
            return _instance;
        }        

        //public List<Restaurant> Restaurants
        //{
        //    get
        //    {
        //        return _restaurants.ToList();
        //    }
        //}

        public IQueryable<Restaurant> Restaurants
        {
            get
            {
                return _restaurants.AsQueryable();
            }
        }
        
        public void Add(Restaurant restaurant)
        {
            lock (Lock)
            {
                _restaurants.Add(restaurant);
            }
        }

        public void Remove(Restaurant restaurant)
        {
            lock (Lock)
            {
                _restaurants.Remove(restaurant);
            }
        }

        public void ClearAll()
        {
            lock (Lock)
            {                
                for(int i = _restaurants.Count - 1; i >= 0; i--) 
                {
                    _restaurants.RemoveAt(i);
                }
            }
        }    
    }
}
