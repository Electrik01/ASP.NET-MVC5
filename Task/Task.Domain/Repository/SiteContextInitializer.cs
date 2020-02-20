using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Domain.Repository
{
    class SiteContextInitializer: CreateDatabaseIfNotExists<SiteContext>
    {
        protected override void Seed(SiteContext db)
        {
       
        }
    }
}
