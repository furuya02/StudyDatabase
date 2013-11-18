using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudyDatabase.Startup))]
namespace StudyDatabase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
