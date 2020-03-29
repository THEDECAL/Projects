using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(week3_chat.Startup))]
namespace week3_chat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
