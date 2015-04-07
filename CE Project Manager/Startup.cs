using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CE_Project_Manager.Startup))]
namespace CE_Project_Manager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
