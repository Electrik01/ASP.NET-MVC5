using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Domain.Entities;
using Task.Domain.Repository;

namespace Task.WebUI.Controllers
{
    public class PollController : Controller
    {
        IRepository repo;

        public PollController(IRepository r)
        {
            repo = r;
        }

        [HttpPost]
        public ActionResult PollAdd(FormCollection formCollection)
        {
            Poll poll = new Poll();
            if (formCollection["poll"] == "Yes")
                poll.Res = 0;
            else if (formCollection["poll"] == "So-so")
                poll.Res = 1;
            else
                poll.Res = 2;
            repo.Save(poll);
            float all = repo.Polls().Count();
            List<float> res = new List<float>()
            {
                repo.Polls().Where(p=>p.Res==0).Count()/all*100,
                repo.Polls().Where(p=>p.Res==1).Count()/all*100,
                repo.Polls().Where(p=>p.Res==2).Count()/all*100
            };
            ViewBag.List = res;
            return PartialView();
        }
    }
}