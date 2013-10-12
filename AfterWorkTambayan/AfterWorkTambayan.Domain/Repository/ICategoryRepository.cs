using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AfterWorkTambayan.Domain.Entities;

namespace AfterWorkTambayan.Domain.Repository
{
    public interface ICategoryRepository
    {
        bool Add(Category category);
        bool Delete(Guid? id);
        Category GetCategory(Guid id);
        IEnumerable<Category> GetCategories();
        void ClearAll();
    }
}
