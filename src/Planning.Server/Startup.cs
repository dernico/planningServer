using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Planning.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Planning.Server
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddCors();

            services.AddDbContext<TodoContext>(options =>
                                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, TodoContext todoContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();



            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost:5000",
                RequireHttpsMetadata = false,

                ApiName = "api1"
            });

            //app.UseJwtBearerAuthentication(new JwtBearerOptions
            //{
            //    Authority = "http://localhost:5000/", // base address of your OIDC server.
            //    Audience = "http://localhost:5001/", // base address of your API.
            //    RequireHttpsMetadata = false
            //});


            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();

            // make sure the tododatabase exists
            todoContext.Database.EnsureCreated();
        }
    }
}
