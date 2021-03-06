using System;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RedSquirrel.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedSquirrel.Models;
using RedSquirrel.Services;
using Serilog;


namespace RedSquirrel
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.RollingFile("log-{Date}.txt")
                .CreateLogger();

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                
                var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                if (appAssembly != null)
                {
                    builder.AddUserSecrets<Startup>();
                }
            }

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var domain = $"https://redsquirrel.auth0.com/";
            
            services.AddMvc();
            
            services.AddTransient<UnitService>();
            services.AddTransient<FoodService>();
            services.AddTransient<LocationService>();
            services.AddTransient<UserService>();
            services.AddTransient<InventoryService>();
            services.AddSingleton<AutoMapperConfiguration>();

            services.AddSingleton(p => p.GetService<AutoMapperConfiguration>().CreateMapper());
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                            .WithOrigins("http://localhost:4200", 
                            "http://app.redsquirrel.io",
                            "*")
                    .WithMethods("GET", "PUT", "POST", "DELETE") 
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(options => 
                options.UseNpgsql(Configuration["ConnectionString"]));
            
            // create a temporary provider. This enables us to still inject the context properly
            // into the User Service so that we can resolve user ids from external ids when 
            // working with the JWT.
            var tempProvider = services.BuildServiceProvider();             
            
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                    options.Authority = "https://redsquirrel.auth0.com/";
                    options.Audience = "gvI7avZ3InJBylWShAhWvox9GLkgCPC5";
                    options.Events = new AuthEvent(tempProvider.GetService<UserService>());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();            
            loggerFactory.AddSerilog();

            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseAuthentication();

            app.UseCors("AllowAll");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

	        app.UseStaticFiles();
        }
    }
}
