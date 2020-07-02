using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockApi.Context;
using StockApi.IServices;
using StockApi.Services;

namespace StockApi
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
            services.AddControllers();

            ///<summary>the connection string  database stock </summary>
            services.AddDbContext<StockContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("StockConnection"));
            });

            
            ///<summary>injecting unit of work that contain all services</summary>
            //services.AddScoped<IAuthentication,Authentication>();
            new CollectionOfServices(services);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }

       
    }

    public class CollectionOfServices
    {
        private IServiceCollection _service;
        public CollectionOfServices(IServiceCollection service)
        {
            _service = service;
            _service.AddDataProtection();
            _service.AddScoped<IAuthentication, AuthenticationService>();
        }
    }
}
