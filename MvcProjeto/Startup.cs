using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcProjeto.Startup))]
namespace MvcProjeto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
