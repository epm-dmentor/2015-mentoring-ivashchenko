using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Http.Dispatcher;
using Mentoring.WEBApi.Controllers;

namespace Mentoring.WEBApi.SelfHost
{
    class Resolver:DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            var ass = new List<Assembly>(base.GetAssemblies());

            var controllers = typeof (MailsController).Assembly;
            if(!ass.Contains(controllers))
            ass.Add(controllers);

            return ass;
        }
    }
}
