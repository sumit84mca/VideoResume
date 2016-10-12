using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoResume.Startup))]
namespace VideoResume
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
