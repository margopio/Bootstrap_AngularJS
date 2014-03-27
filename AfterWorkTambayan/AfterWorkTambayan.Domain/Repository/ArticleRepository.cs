using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AfterWorkTambayan.Domain.Entities;

namespace AfterWorkTambayan.Domain.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private InMemoryArticle _instance;

        public ArticleRepository()
        {
            _instance = InMemoryArticle.GetInstance();
        }

        public bool Add(Article article)
        {
            var flag = false;
            try
            {
                _instance.Add(article);
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
                var article = _instance.Articles.FirstOrDefault(r => r.ArticleId == id);
                if (article != null)
                {
                    _instance.Remove(article);
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;                
            }
            return flag;
        }

        public Article GetArticle(Guid id)
        {
            var article = _instance.Articles.FirstOrDefault(r => r.ArticleId == id);
            return article;
        }

        public IEnumerable<Article> GetArticles()
        {
            return _instance.Articles;            
        }

        public void ClearAll()
        {
            _instance.ClearAll();
        }

    }
}
