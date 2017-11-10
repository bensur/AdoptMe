using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdoptMe.Startup))]
namespace AdoptMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
        //public void ConfigureServices()
        //{
        //    services.AddIdentity<ApplicationUser, IdentityRole>()
        //    .AddEntityFrameworkStores<ApplicationDbContext>()
        //    .AddDefaultTokenProviders();

        //        services.AddAuthentication().AddGoogle(googleOptions =>
        //        {
        //            googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
        //            googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
        //        });

        //}

    }
}
