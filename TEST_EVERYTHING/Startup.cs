using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TEST_EVERYTHING.Startup))]
namespace TEST_EVERYTHING
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
