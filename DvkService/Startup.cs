using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DvkService.Startup))]
namespace DvkService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
