using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CandidatosSistema.Startup))]
namespace CandidatosSistema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
