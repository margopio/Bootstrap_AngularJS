using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AfterWorkTambayan.Domain.Entities;

namespace AfterWorkTambayan.Domain.Repository
{
    public interface IArticleRepository
    {
        bool Add(Article article);
        bool Delete(Guid id);
        Article GetArticle(Guid id);
        IEnumerable<Article> GetArticles();
        void ClearAll();
    }
}
