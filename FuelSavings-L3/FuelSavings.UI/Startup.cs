using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FuelSavings.UI.Startup))]
namespace FuelSavings.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
