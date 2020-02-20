using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Domain.Repository
{
    public class ArtRevRepository : IRepository
    {
        private SiteContext db = new SiteContext();

        public void Del(Article article)
        {
            db.Articles.Remove(article);
        }
        public IEnumerable<Review> Reviews()
        {
            return db.Reviews;
        }

        public IEnumerable<Article> Articles()
        {
            return db.Articles;
        }

        public IEnumerable<Tag> Tags()
        {
            return db.Tags;
        }

        public IEnumerable<Poll> Polls()
        {
            return db.Polls;
        }

        public void Edit(Article article)
        {
            db.Entry(article).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Save(Review r)
        {
            db.Reviews.Add(r);
            db.SaveChanges();
        }
        public void Save(Poll r)
        {
            db.Polls.Add(r);
            db.SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Save(Article r)
        {
            db.Articles.Add(r);
            db.SaveChanges();
        }

        public void Save(Tag r)
        {
            db.Tags.Add(r);
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
