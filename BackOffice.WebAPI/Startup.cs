using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(BackOffice.WebAPI.Startup))]
namespace BackOffice.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}