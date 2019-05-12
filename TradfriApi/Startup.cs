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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TradfriApi.Tradfri;
using TradfriApi.Tradfri.Models;

namespace TradfriApi
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
            var section = Configuration.GetSection("TradfriSettings");
            services.Configure<TradfriSettings>(section);
            var settings = section.Get<TradfriSettings>();

            settings.GatewayName = settings.GatewayName ?? Environment.GetEnvironmentVariable("GATEWAY_NAME");
            settings.GatewayIp = settings.GatewayIp ?? Environment.GetEnvironmentVariable("GATEWAY_IP");
            settings.GatewayPSK = settings.GatewayPSK ?? Environment.GetEnvironmentVariable("GATEWAY_PSK");
            settings.ApplicationName = settings.ApplicationName ?? Environment.GetEnvironmentVariable("APPLICATION_NAME");
            settings.ApplicationPSK = settings.ApplicationPSK ?? Environment.GetEnvironmentVariable("APPLICATION_PSK");

            if (string.IsNullOrEmpty(settings.GatewayName))
            {
                Console.WriteLine("You have to set the GatewayName in the appsettings.json file or as 'GATEWAY_NAME' environment variable.");
                Environment.Exit(1);
            }
            if (string.IsNullOrEmpty(settings.GatewayIp))
            {
                Console.WriteLine("You have to set the GatewayIp in the appsettings.json file or as 'GATEWAY_IP' environment variable.");
                Environment.Exit(1);
            }
            if (string.IsNullOrEmpty(settings.ApplicationName))
            {
                Console.WriteLine("You have to set the ApplicationName in the appsettings.json file or as 'APPLICATION_NAME' environment variable.");
                Environment.Exit(1);
            }

            var controller = new TradfriController(settings.GatewayName, settings.GatewayIp);

            if (string.IsNullOrEmpty(settings.ApplicationPSK))
            {
                Console.WriteLine("The ApplicationPSK is not configured in the appsettings.json neither the 'APPLICATION_PSK' environment variable. Creating a new ApplicationPSK");

                if (string.IsNullOrEmpty(settings.GatewayPSK))
                {
                    Console.WriteLine("The GatewayPSK is empty, please add it to the appsettings.json file or as environment variable.");
                    Console.WriteLine("You can find the Gateway PSK on the backside of your Gateway.");
                    Environment.Exit(1);
                }

                var appSecret = controller.GenerateAppSecret(settings.GatewayPSK, settings.ApplicationName);
                if (appSecret != null)
                {
                    settings.ApplicationPSK = appSecret.PSK;
                    Console.WriteLine("A new ApplicationPSK was created, please copy this in a safe place and put the value in the appsetings.json file or in the 'APPLICATION_PSK' environment variable.");
                    Console.WriteLine("ApplicationPSK = " + settings.ApplicationPSK);
                    Console.WriteLine();
                }
                else
                    throw new Exception("The Gateway return a null AppSecret, please change the application name and try again.");
            }
            controller.ConnectAppKey(settings.ApplicationPSK, settings.ApplicationName);
            services.AddSingleton<TradfriController>(controller);

            var devices = controller.GatewayController.GetDeviceObjects().Result;

            services
                .AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    options.SerializerSettings.Formatting = Formatting.Indented;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddOpenApiDocument(options =>
            {
                options.Title = "Tradfri Api";
                options.Version = "0.1.0";
            });
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
            app.UseSwagger(); // serve OpenAPI/Swagger documents
            app.UseSwaggerUi3(); // serve Swagger UI
            app.UseReDoc(); // serve ReDoc UI
        }
    }
}
