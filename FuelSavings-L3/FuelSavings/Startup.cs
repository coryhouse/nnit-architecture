using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FuelSavings.Startup))]
namespace FuelSavings
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
