using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Domain.Entities;
using Task.Domain.Repository;

namespace Task.WebUI.Controllers
{
    public class ReviewController : Controller
    {
        IRepository repo;

        public ReviewController(IRepository r)
        {
            repo = r;
        }

        public ActionResult ShowReview(int page = 1)
        {
            int PageSize = repo.Reviews().Count() / 4;
            return View(repo.Reviews());
        }

        public ActionResult AddReview()
        {
            return View("AddReview");
        }
        [HttpPost]
        public ActionResult AddReview(Review review)
        {
            if (ModelState.IsValid)
            {
                review.Data = DateTime.Now;
                repo.Save(review);
            }
            return View("AddReview");
        }
    }
}