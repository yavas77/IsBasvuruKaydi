using FluentValidation.AspNetCore;
using IsBasvuruKaydi.Bussiness.Abstract;
using IsBasvuruKaydi.Bussiness.Concrete;
using IsBasvuruKaydi.Bussiness.ValidationRules.FluentValidation.AccountValidotors;
using IsBasvuruKaydi.DataAccess.Abstract;
using IsBasvuruKaydi.DataAccess.Concrete.Contexts;
using IsBasvuruKaydi.DataAccess.Concrete.EntityFramework.Repository;
using IsBasvuruKaydi.Entities.Concrete;
using IsBasvuruKaydi.MvcHelpers.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.WebUI
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

            services.AddSession();
            services.AddDbContext<IsBasvuruKaydiContext>();

            

            services.AddIdentity<User, Role>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 4;
            }).AddEntityFrameworkStores<IsBasvuruKaydiContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Account/Login/");
                opt.Cookie.HttpOnly = true;
                opt.Cookie.Name = "IsBasvuruKaydi";
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.SlidingExpiration = true;
            });

            services.AddControllersWithViews()
                .AddFluentValidation(config =>
                {
                    config.RegisterValidatorsFromAssemblyContaining(typeof(RegisterValidator));
                });

            services.AddHttpContextAccessor();

            services.AddScoped(typeof(IBaseDal<>), typeof(EfBaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseManager<>));

            services.AddScoped<ICvService, CvManager>();
            services.AddScoped<ICvDal, EfCvRepository>();

            services.AddScoped<IAccountService, AccountManager>();

            services.AddAutoMapper(typeof(Startup));
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

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Basvuru}/{action=Ekle}/{id?}");
            });

            ActionResultExtensions.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>(),
              app.ApplicationServices.GetRequiredService<ITempDataDictionaryFactory>());
        }
    }
}
