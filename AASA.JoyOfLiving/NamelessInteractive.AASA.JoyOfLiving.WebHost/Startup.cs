using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NamelessInteractive.AASA.JoyOfLiving.WebHost.Startup))]

namespace NamelessInteractive.AASA.JoyOfLiving.WebHost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
