using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jungkookie.Startup))]
namespace jungkookie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
