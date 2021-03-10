using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assign5.Models;
using Microsoft.AspNetCore.Http;

namespace Assign5
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
            //allows the model to connect with the sequel Database
            services.AddControllersWithViews();

            services.AddDbContext<OidoDBContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:OidoBooksConnection"]);
            });

            services.AddScoped<iOidoRepository, EFOidoRepository>();

            //This enables the ability to add razor pages
            services.AddRazorPages();
            //this is to make sure we can create sessions
            services.AddDistributedMemoryCache();
            services.AddSession();
            // Added this from the book
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
            //This will set up a session when the user accesses the website
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", Action = "Index" }
                    );

                endpoints.MapControllerRoute("page",
                    "{pageNum:int}",
                    new { Controller = "Home", Action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", Action = "Index", pageNum = 1 });

                endpoints.MapControllerRoute(
                "pagination",
                "/P{pageNum}",
                new { Controller = "Home", action = "Index" });



                endpoints.MapDefaultControllerRoute();

                // this is to send stuff to the razor pages
                endpoints.MapRazorPages();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
