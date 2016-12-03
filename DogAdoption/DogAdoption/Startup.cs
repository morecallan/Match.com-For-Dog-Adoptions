using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DogAdoption.Startup))]
namespace DogAdoption
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
