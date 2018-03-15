using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TripRqst.Startup))]
namespace TripRqst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }

      
    }
}
