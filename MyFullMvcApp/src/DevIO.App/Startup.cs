using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevIO.App.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DevIO.Data.Context;
using DevIO.Business.Interfaces;
using DevIO.Data.Repository;
using AutoMapper;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using DevIO.App.Extensions;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace DevIO.App
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc(options => {
                options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => "The filled value is invalid for this field.");
                options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => "This field needs to be completed.");
                options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "This field needs to be completed.");
                options.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => "The body in the request must not be empty.");
                options.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor(x => "The filled value is invalid for this field.");
                options.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => "The filled value is invalid for this field.");
                options.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => "The field must be numeric.");
                options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(x => "The filled value is invalid for this field.");
                options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(x => "The filled value is invalid for this field.");
                options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => "The field must be numeric.");
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "This field needs to be completed.");
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<MyDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, CurrencyValidationAttributeAdapterProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            var defaultCulture = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };

            app.UseRequestLocalization(localizationOptions);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
