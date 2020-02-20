using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Task.Domain.Entities;

namespace Task.Domain.Repository
{
    public class SiteContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
