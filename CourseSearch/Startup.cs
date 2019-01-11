using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseSearch.Startup))]
namespace CourseSearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
