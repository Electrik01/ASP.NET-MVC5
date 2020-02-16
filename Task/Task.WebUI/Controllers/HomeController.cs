using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Domain.Repository;
using Task.Domain.Pagination;
using Task.Domain.Entities;
using Task.WebUI.Models;

namespace Task.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository repo;

        public HomeController(IRepository r)
        {
            repo = r;
        }
        [HttpGet]
        public ActionResult Index(string tag = "", int page = 1)
        {
            int pageSize = 4;
            IEnumerable<Article> articlesPerPages = repo.Articles().Skip((page - 1) * pageSize).Where(a => a.Tags.Contains(tag)).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = repo.Articles().Where(a => a.Tags.Contains(tag)).Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Articles = articlesPerPages };
            return View(ivm);
        }

        [HttpPost]
        public ActionResult Index(string Name)
        {

            Article article = repo.Articles().Where(a => a.Name == Name)
                            .FirstOrDefault();
            ArtAbout artAbout = new ArtAbout(article, article.Tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            return View("ArtAbout", artAbout);
        }


        public ActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Test(FormCollection formCollection)
        {
            int count = 0;
            if (formCollection["Sum"] == "4") count++;
            if (formCollection["Sun"] == "East") count++;
            if (formCollection["Chb1"][0] == 't') count++;
            if (formCollection["Chb3"][0] == 't') count++;
            ViewBag.Res = count;
            return View("Result");
        }
    }
}