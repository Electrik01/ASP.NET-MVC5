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
        public ActionResult Index(int tag_id = 1, int page = 1)
        {
            ArtShort artShort = new ArtShort(repo.Tags()
                                            .Where(t=>t.Id==tag_id)
                                            .FirstOrDefault()
                                            .Articles
                                            .Where(a=>a.IsShow==true && a.IsDel==false),page);
            return View(artShort);
        }

        [HttpPost]
        public ActionResult Index(string Name)
        {

            Article article = repo.Articles().Where(a => a.Name == Name)
                            .FirstOrDefault();
            ArtAbout artAbout = new ArtAbout(article);
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