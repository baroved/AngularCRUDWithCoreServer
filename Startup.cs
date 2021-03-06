using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using Microsoft.EntityFrameworkCore;
using ServerCore.DAL;
using ServerCore.Infra;
using ServerCore.Services;
using ServerCore.Repository;
using Microsoft.Net.Http.Headers;

namespace ServerCore
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
            services.AddCors(options =>
            {
                options.AddPolicy("test", builder =>
                {
                    builder.WithOrigins("http://localhost:4200").WithHeaders(HeaderNames.ContentType, "Access-Control-Allow-Methods", "GET, POST, OPTIONS, PUT, DELETE");
                });

            });
            services.AddControllers().AddNewtonsoftJson();
            services.AddScoped<IDogsService, DogsService>();
            services.AddScoped<ICarsService, CarsService>();
            services.AddScoped<IBeersService, BeersService>();
            services.AddScoped<BeersRepository>();
            services.AddScoped<CarsRepository>();
            services.AddScoped<DogsRepository>();
            services.AddDbContext<DBContext>(options =>
options.UseSqlServer(Configuration.GetConnectionString("Default")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("test");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
