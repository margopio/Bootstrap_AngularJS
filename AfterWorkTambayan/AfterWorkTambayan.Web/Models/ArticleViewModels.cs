using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AfterWorkTambayan.Domain.Entities;
using System.Web.Mvc;

namespace AfterWorkTambayan.Web.Models
{
    public class GetArticleViewModel
    {
        public Article Article { get; set; }
    }

    public class ListArticlesViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}