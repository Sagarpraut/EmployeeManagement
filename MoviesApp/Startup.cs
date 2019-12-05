using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoviesApp.Models;
using MediatR;
using AutoMapper;
using MoviesApp.Models.Mapper;

namespace MoviesApp
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
            //session
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(6);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //Mapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //DB Connection
            var connection = Configuration.GetConnectionString("EmpDB");
            services.AddDbContext<EmpDBContext>(options => options.UseSqlServer(connection));

            //DataaccessLayer
            services.AddTransient<IUserDataAccessLayer, DataAccessSql>();
            services.AddTransient<IEmpDataAccessLayer, EmpDataAccessLayer2>();
            
            //AddMVC Register Framework services
            services.AddControllersWithViews(); 
   
            //mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Add Middleware components 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //enable to use developer exceptions    
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();//enable the static pages to use
            app.UseSession();
            app.UseRouting();
            app.UseAuthorization();

            //Routing The req.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
