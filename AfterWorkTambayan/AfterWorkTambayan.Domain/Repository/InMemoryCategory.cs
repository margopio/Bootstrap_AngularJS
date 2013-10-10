using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AfterWorkTambayan.Domain.Entities;

namespace AfterWorkTambayan.Domain.Repository
{
    public class InMemoryCategory
    {       
        private static List<Category> _categories;
        private static InMemoryCategory _instance = null;
        private static readonly object Lock = new object();

        private InMemoryCategory()
        {           
            _categories = new List<Category>();            
        }

        public static InMemoryCategory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new InMemoryCategory();
            }
            return _instance;
        }     

        public IQueryable<Category> Categories
        {
            get
            {
                return _categories.AsQueryable();
            }
        }

        public void Add(Category category)
        {
            lock (Lock)
            {
                _categories.Add(category);
            }
        }
        
        public void Remove(Category category)
        {
            lock (Lock)
            {
                _categories.Remove(category);
            }
        }
        
        public void ClearAll()
        {
            lock (Lock)
            {
                for (int i = _categories.Count - 1; i >= 0; i--)
                {
                    _categories.RemoveAt(i);
                }
            }
        }    
    }
}
