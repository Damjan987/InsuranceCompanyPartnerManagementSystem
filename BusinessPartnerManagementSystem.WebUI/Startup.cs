using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusinessPartnerManagementSystem.WebUI.Startup))]
namespace BusinessPartnerManagementSystem.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
