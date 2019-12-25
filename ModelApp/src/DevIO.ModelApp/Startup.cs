using DevIO.ModelApp.Data;
using DevIO.ModelApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DevIO.ModelApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Modules/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Modules/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IOperationTransient, Operation>();
            services.AddScoped<IOperationScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.Empty));

            services.AddTransient<OperationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );

                //routes.MapRoute(
                //    name: "areas",
                //    template: "{area:exists}/{action=Index}/{id?}"
                //);


                routes.MapAreaRoute(
                    name: "ProductsArea",
                    areaName: "Products",
                    template: "Products/{controller=Register}/{action=Index}/{id?}"
                );

                routes.MapAreaRoute(
                    name: "SalesArea", 
                    areaName: "Sales",
                    template: "Sales/{controller=Orders}/{action=Index}/{id?}"
                );
            });
        }
    }
}
