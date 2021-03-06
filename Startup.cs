using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SekiroApp.Services;
using SekiroApp.Data;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;

namespace SekiroApp
{
    public class Startup
    {
        /*private readonly IConfiguration _config;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public Startup(IConfiguration config)
        {
            _config = config;
        }*/

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SekiroContext>();
            /*services.AddDbContext<SekiroContext>(config =>
            {
                config.UseSqlServer(_config.GetConnectionString("SekiroConnectionString"));
            });*/

            services.AddTransient<SekiroSeeder>();

            services.AddTransient<IMailService, NullMailService>();

            services.AddScoped<ISekiroRepository, SekiroRepository>();

            services.AddMvc();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("Default",
                    "/{controller}/{action}/{id?}",
                    new { controller = "App", action = "Index" });
            });
            /*app.Run(async context =>
            {
                await context.Response.WriteAsync("hi");
            });*/
        }
    }
}
