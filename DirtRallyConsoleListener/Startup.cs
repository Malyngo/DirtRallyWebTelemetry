using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin.Cors;
using Nancy;
using Nancy.Owin;
using Nancy.Conventions;

namespace DirtRallyConsoleListener
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
            app.UseNancy();
        }
    }
}

