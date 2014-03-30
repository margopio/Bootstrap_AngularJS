using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AfterWorkTambayan.Web.Model;
using AfterWorkTambayan.Domain.Entities;
using AfterWorkTambayan.Web.Utilities;
using System.Threading;
using AfterWorkTambayan.Domain.Repository;
using AfterWorkTambayan.Web.Models;

namespace AfterWorkTambayan.Web.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleRepository _repositoryArticle;

        public ArticleController()
        {
            _repositoryArticle = new ArticleRepository();
        }

        //
        // GET: /Article/

        public ActionResult Index()
        {
            //
            if (!_repositoryArticle.GetArticles().Any())
            {
            _repositoryArticle.ClearAll();
            Article article = new Article();
            article.ArticleId = Guid.NewGuid();
            article.Title = "Article 1";
            article.Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae.\n Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim.";
            article.ImageUrl = "TestImage.gif";
            article.AddedBy = "Tester 1";
            article.DateAdded = DateTime.Now;
            article.Caption = "Text can be up to 30 chars long.";
            _repositoryArticle.Add(article);

            article = new Article();
            article.ArticleId = Guid.NewGuid();
            article.Title = "Article 2";
            article.Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae.\n Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim.";
            article.ImageUrl = "TestImage.gif";
            article.AddedBy = "Tester 2";
            article.DateAdded = DateTime.Now.AddDays(-1);
            article.Caption = "Text can be up to 30 chars long.";
            _repositoryArticle.Add(article);

            article = new Article();
            article.ArticleId = Guid.NewGuid();
            article.Title = "Article 3";
            article.Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim.\n" + 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " + 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " + 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " + 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " + 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " + 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " + 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " + 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " + 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim.\n" +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim.\n\n" +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " + 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim.\n\n" + 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " + 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim.\n\n" +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. " +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim.\n" +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim. "
                ;
            article.ImageUrl = "TestImage.gif";
            article.AddedBy = "Tester 3";
            article.DateAdded = DateTime.Now.AddDays(-2);
            article.Caption = "Text can be up to 30 chars long.";
            _repositoryArticle.Add(article);
            }
            //

            ListArticlesViewModel articleViewModel = new ListArticlesViewModel();
            articleViewModel.Articles = (from a in _repositoryArticle.GetArticles()
                                        orderby a.Title, a.DateAdded descending
                                        select new Article
                                        {
                                            ArticleId = a.ArticleId,
                                            ImageUrl = "/Images/" + a.ImageUrl,
                                            Title = a.Title,
                                            Body = a.Body.Length <= 500 ? a.Body : a.Body.Substring(0, Math.Min(a.Body.Length, 500)),
                                            Caption = a.Caption,
                                            AddedBy = a.AddedBy,
                                            DateAdded = a.DateAdded
                                        }).ToList();

            return View(articleViewModel);
        }

        //
        // GET: /Article/GetArticle

        public ActionResult GetArticle(Guid articleId)
        {
            GetArticleViewModel articleViewModel = new GetArticleViewModel();
            var article = _repositoryArticle.GetArticle(articleId);
            if (article != null)
            {
                articleViewModel.Article = new Article()
                {
                    ArticleId = article.ArticleId,
                    Title = article.Title,
                    Body = article.Body,
                    Caption = article.Caption,
                    ImageUrl = "/Images/" + article.ImageUrl,
                    AddedBy = article.AddedBy,
                    DateAdded = article.DateAdded
                };
            }

            return View(articleViewModel);
        }

        //
        // GET: /Add Article/

        public ActionResult AddArticle()
        {
            GetArticleViewModel articleViewModel = new GetArticleViewModel();
            articleViewModel.Article = new Article();           
            ViewBag.Status = "Add";
            return View(articleViewModel);
        }

        //
        // POST: /Add Article/

        [HttpPost]
        public ActionResult AddArticle(GetArticleViewModel articleViewModel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                Article article = new Article();
                article.ArticleId = Guid.NewGuid();
                article.Title = articleViewModel.Article.Title;
                article.AddedBy = articleViewModel.Article.AddedBy;
                article.DateAdded = DateTime.Now;
                article.Body = articleViewModel.Article.Body;
                article.Caption = articleViewModel.Article.Caption;                

                if (file != null)
                {
                    string path = Server.MapPath("~/Images");

                    if (file.ContentLength > 5000000)
                    {
                        ModelState.AddModelError("file", "The size of the file should not exceed 5 MB");
                        return View();
                    }

                    var supportedTypes = new[] { "jpg", "jpeg", "png", "bmp", "gif" };

                    var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);

                    if (!supportedTypes.Contains(fileExt))
                    {
                        ModelState.AddModelError("file", "Invalid type. Only the following types (jpg, jpeg, png, bmp, gif) are supported.");
                        return View();
                    }

                    file.SaveAs(path + "/"  + file.FileName);

                    article.ImageUrl = file.FileName;
                    //_repositoryArticle.Add(article);
                }

                _repositoryArticle.Add(article);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Please fix error(s) in order to continue.");
                ViewBag.Status = "Add";
                return View(articleViewModel);
            }
        }
    }
}
