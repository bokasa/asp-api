﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ICommands;
using Application.ICommands.Category;
using Application.ICommands.Comment;
using EfCommands.CategoryCommands;
using EfCommands.CommentCommands;
using EfCommands;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<Context>();
            services.AddTransient<IGetAdsCommand, GetAds>();
            services.AddTransient<IGetUsersCommand, GetUsers>();
            services.AddTransient<IGetCategoriesCommand, GetCategories>();
            services.AddTransient<IGetCommentsCommand, GetComments>();
            services.AddTransient<IGetAdCommand, GetAd>();
            services.AddTransient<IGetUserCommand, GetUser>();
            services.AddTransient<IGetCategoryCommand, GetCategory>();
            services.AddTransient<IGetCommentCommand, GetComment>();
            services.AddTransient<ICreateAdCommand, CreateAd>();
            services.AddTransient<IDeleteAdCommand, DeleteAd>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
