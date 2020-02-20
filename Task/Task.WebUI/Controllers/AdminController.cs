using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Domain.Repository;
using Task.Domain.Entities;

namespace Task.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IRepository repo;

        public AdminController(IRepository r)
        {
            repo = r;
        }

        public ActionResult Add()
        {
            IEnumerable<Article> articles = repo.Articles().Where(a => a.IsShow == false);
            return View(articles);
        }

        public ActionResult Confirm(int id)
        {
            Article article = repo.Articles().Where(a => a.ID == id).FirstOrDefault();
            article.IsShow = true;
            repo.SaveChanges();
            return RedirectToAction("Add");
        }

        public ActionResult Delete(int id)
        {
            Article article = repo.Articles().Where(a => a.ID == id).FirstOrDefault();
            article.IsDel=true;
            repo.SaveChanges();
            return RedirectToAction("Del");
        }

        public ActionResult Del()
        {
            IEnumerable<Article> articles = repo.Articles().Where(a => a.IsDel == false);
            return View(articles);
        }
    
        public ActionResult Edit()
        {
            return View(repo.Articles().Where(a => a.IsDel == false));
        }

        [HttpGet]
        public ActionResult EditArt(int id)
        {
            return View("EditArt", repo.Articles().Where(a => a.ID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult EditArt(Article article)
        {
            repo.Edit(article);
            return RedirectToAction("Add");
        }
    }
}