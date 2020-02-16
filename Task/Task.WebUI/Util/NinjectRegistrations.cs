using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Domain.Repository;
using Ninject.Modules;

namespace Task.WebUI.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<ArtRevRepository>();
        }
    }
}