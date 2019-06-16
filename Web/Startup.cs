using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ICommands;
using Application.ICommands.Category;
using Application.ICommands.User;
using EfCommands;
using EfCommands.CategoryCommands;
using EfCommands.UserCommands;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web
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


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<Context>();
            services.AddTransient<IGetCategoriesCommand, GetCategories>();
            services.AddTransient<IGetCategoryCommand, GetCategory>();
            services.AddTransient<IAddCategoryCommand, AddCategory>();
            services.AddTransient<IDeleteCategoryCommand, DeleteCategory>();
            services.AddTransient<IEditCategoryCommand, EditCategory>();

            services.AddTransient<IGetUserCommand, GetUser>();
            services.AddTransient<IGetUsersCommand, GetUsers>();
            services.AddTransient<IEditUserCommand, EditUser>();
            services.AddTransient<ICreateUserCommand, CreateUser>();
            services.AddTransient<IDeleteUserCommand, DeleteUser>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
