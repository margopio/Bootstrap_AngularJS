using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AfterWorkTambayan.Domain.Entities;

namespace AfterWorkTambayan.Domain.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private InMemoryCategory _instance;

        public CategoryRepository()
        {
            _instance = InMemoryCategory.GetInstance();
        }        
        
        public bool Add(Category category)
        {
            var flag = false;
            try
            {
                _instance.Add(category);
                flag = true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return flag;
        }

        public bool Delete(Guid? id)
        {
            var flag = false;
            try
            {
                var category = _instance.Categories.FirstOrDefault(r => r.CategoryId == id);
                if (category != null)
                {
                    _instance.Remove(category);
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;                
            }
            return flag;
        }
        
        public Category GetCategory(Guid id)
        {
            var category = _instance.Categories.FirstOrDefault(r => r.CategoryId == id);
            return category;
        }
        
        public IEnumerable<Category> GetCategories()
        {
            return _instance.Categories;
        }
        
        public void ClearAll()
        {
            _instance.ClearAll();
        }
    }
}
