using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EFfirst.Startup))]
namespace EFfirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
         
        }
    }
}
