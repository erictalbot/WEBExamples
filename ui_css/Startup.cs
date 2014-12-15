using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ui_css.Startup))]
namespace ui_css
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
