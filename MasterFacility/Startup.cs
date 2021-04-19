using MasterFacility.Data;
using MasterFacility.Data.Models.Identity;
using MasterFacility.Services.Culture;
using MasterFacility.Services.UserSession;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Westwind.Globalization;
using Westwind.Globalization.AspnetCore;

namespace MasterFacility
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
            });
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // localization services
            // Standard ASP.NET Localization features are recommended
            // Make sure this is done FIRST!
            services.AddLocalization(options =>
            {
                // I prefer Properties over the default `Resources` folder
                // due to namespace issues if you have a Resources type as
                // most people do for shared resources.
                options.ResourcesPath = "Properties";
            });


            // Replace StringLocalizers with Db Resource Implementation
            services.AddSingleton(typeof(IStringLocalizerFactory),
                                  typeof(DbResStringLocalizerFactory));

            //services.AddSingleton(typeof(IHtmlLocalizerFactory),
            //                      typeof(DbResHtmlLocalizerFactory));


            // Required: Enable Westwind.Globalization (opt parm is optional)
            // shown here with optional manual configuration code
            services.AddWestwindGlobalization(opt =>
            {
                // the default settings comme from DbResourceConfiguration.json if exists
                // you can override the settings here, the config you create is added
                // to the DI system (DbResourceConfiguration)

                // Resource Mode - from Database (or Resx for serving from Resources)
                opt.ResourceAccessMode = ResourceAccessMode.DbResourceManager;  // .Resx

                // Make sure the database you connect to exists
                opt.ConnectionString = Configuration.GetConnectionString("DefaultConnection");

                // Database provider used - Sql Server is the default
                opt.DataProvider = DbResourceProviderTypes.PostgreSql;

                // The table in which resources are stored
                opt.ResourceTableName = "localizations";

                opt.AddMissingResources = false;
                opt.ResxBaseFolder = "~/Properties/";

                // Set up security for Localization Administration form
                opt.ConfigureAuthorizeLocalizationAdministration(actionContext =>
                {
                    // return true or false whether this request is authorized
                    return true;   //actionContext.HttpContext.User.Identity.IsAuthenticated;
                });
            });

            services.AddTransient<ICulture, Culture>();
            services.AddTransient<IUserSession, UserSession>();
            services.AddControllers().AddNewtonsoftJson().AddViewLocalization().AddDataAnnotationsLocalization();

            services.AddTransient<IViewLocalizer, DbResViewLocalizer>();


            services.Configure<RequestLocalizationOptions>(
              options =>
              {
                  var supportedCultures = new[]
                  {
                         new CultureInfo("en-US"),
                         new CultureInfo("prs-AF") { DateTimeFormat = { Calendar = new GregorianCalendar() } },
                         new CultureInfo("ps-AF"){ DateTimeFormat = { Calendar = new GregorianCalendar() } }
                  };

                  options.DefaultRequestCulture = new RequestCulture("prs-AFs");
                  options.SupportedCultures = supportedCultures;
                  options.SupportedUICultures = supportedCultures;

                     //options.RequestCultureProviders.Insert(0, new RouteValueRequestCultureProvider());
                 });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            // Localization 
            var supportedCultures = new[]
                     {
                         new CultureInfo("en-US"),
                         new CultureInfo("prs-AF") { DateTimeFormat = { Calendar = new GregorianCalendar() } },
                         new CultureInfo("ps-AF"){ DateTimeFormat = { Calendar = new GregorianCalendar() } }
                     };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                // code for configuration modular start //
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                // code for configuration modular end //

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

           
        }
    }
}
