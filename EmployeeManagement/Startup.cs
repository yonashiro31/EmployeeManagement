using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using EmployeeManagement.Helper;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EmployeeManagement.Session.Interface;
using EmployeeManagement.Session;

namespace EmployeeManagement
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


            //TODO DI‚ÉŽg‚¤ƒNƒ‰ƒX‚ð’Ç‰Á
            //helper
            services.AddTransient<IEV0001Helper,EV0001Helper>();
            services.AddTransient<IEV0002Helper, EV0002Helper>();

            //Logic

            //DataAccessservice
            services.AddTransient<IEV8002Logic, EV8002Logic>();
            services.AddTransient<IEV8003Logic, EV8003Logic>();
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=SCRN0001}/{action=Index}/{id?}");
            });
        }
    }
}
