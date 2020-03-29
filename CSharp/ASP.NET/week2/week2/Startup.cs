using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(week2.Startup))]
namespace week2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
