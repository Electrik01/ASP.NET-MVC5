using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Domain.Entities;
using Task.Domain.Repository;

namespace Task.WebUI.Controllers
{
    public class ArtAddController : Controller
    {
        IRepository repo;
        
        public ArtAddController(IRepository r)
        {
            repo = r;
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Article article, string tags)
        {

            string[] tags_l = tags.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
            if (!tags_l.Contains("Article")) article.Tags.Add(repo.Tags().Where(t=>t.Name=="Article").FirstOrDefault());
                for(int i=0;i<tags_l.Length;i++)
                {
                    var tag = repo.Tags().Where(t => tags_l[i].Contains(t.Name)).FirstOrDefault();
                    if (tag !=null)
                    {
                        article.Tags.Add(tag);
                    }
                    else
                    {
                        Tag tag_n = new Tag() { Name = tags_l[i] };
                        repo.Save(tag_n);
                        article.Tags.Add(repo.Tags().Where(t => tags_l[i].Contains(t.Name)).FirstOrDefault());
                    }
                }

                article.Data = DateTime.Now;

                repo.Save(article);
            
            return View();
        }

  
    }
}