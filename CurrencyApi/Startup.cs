using System.Collections.Generic;

using CurrencyApi.Services;
using CurrencyApi.Services.Calculators;
using CurrencyApi.Services.Validators;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CurrencyApi
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
            services.AddSingleton<ICurrencyService, CurrencyService>();
            services.AddSingleton<ICurrencyProvider>(x => new CentralBankSoapCurrencyProvider(Configuration["DailyInfoRemoteAddress"]));
            services.AddSingleton(
                s => new CoordinateInCircleCurrencyRequestValidator(
                    this.Configuration.GetIntOrDefault("circle-radius", 8),
                    this.Configuration.GetIntOrDefault("circle-center-x", 0),
                    this.Configuration.GetIntOrDefault("circle-center-y", 0)));

            services.AddSingleton<NotTomorrowCurrencyRequestDateValidator>();

            services.AddSingleton<ICurrencyDateCalculator>(
                s => new CartesianCoordinateSystemCalculator(
                    new List<ICurrencyRequestValidator> { s.GetService<CoordinateInCircleCurrencyRequestValidator>() },
                    new List<ICurrencyRequestDateValidator> { s.GetService<NotTomorrowCurrencyRequestDateValidator>() }));

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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
