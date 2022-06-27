using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.Business;
using TomTec.Intermed.Data;
using TomTec.Intermed.Lib.AspNetCore;
using TomTec.Intermed.Lib.AspNetCore.Filters;

namespace TomTec.Intermed.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Global.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<IntermedDBContext>();
            services.AddControllers();
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));
            services.AddScoped(typeof(ICreditCardInfoService), typeof(CreditCardInfoService));
            services.AddScoped(typeof(ISignatureService), typeof(SignatureService));

            //Exceptions Handlings
            services.AddScoped<KeyNotFoundExceptionFilterAttribute>();
            services.AddScoped<UnauthorizedAccessExceptionFilterAttribute>();
            services.AddScoped<GenericExceptionFilterAttribute>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile($"D:\\Intermed\\Logs\\log-intermed-api_{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss")}"); 

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(op => op
                .WithOrigins(new[]{@"http://localhost:3000",
                    @"http://localhost:8080",
                    @"http://localhost:4200",
                    @"https://localhost:44392",
                    @"https://doctud-lucdee.vercel.app" })
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
