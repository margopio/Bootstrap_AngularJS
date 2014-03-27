using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AfterWorkTambayan.Domain.Entities;

namespace AfterWorkTambayan.Domain.Repository
{
    public class InMemoryArticle
    {
        private static List<Article> _articles;
        private static InMemoryArticle _instance = null;
        private static readonly object Lock = new object();

        private InMemoryArticle()
        {
            _articles = new List<Article>();            
        }

        public static InMemoryArticle GetInstance()
        {
            if (_instance == null)
            {
                _instance = new InMemoryArticle();
            }
            return _instance;
        }

        public IQueryable<Article> Articles
        {
            get
            {
                return _articles.AsQueryable();
            }
        }

        public void Add(Article article)
        {
            lock (Lock)
            {
                _articles.Add(article);
            }
        }

        public void Remove(Article article)
        {
            lock (Lock)
            {
                _articles.Remove(article);
            }
        }

        public void ClearAll()
        {
            lock (Lock)
            {
                for (int i = _articles.Count - 1; i >= 0; i--)
                {
                    _articles.RemoveAt(i);
                }
            }
        }
    }
}
