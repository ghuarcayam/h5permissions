using Autofac;
using Autofac.Extensions.DependencyInjection;
using Confluent.Kafka;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using N5.BuildingBlocks.Infrastructure.EventBus;
using N5.PermissionsManager.API.Configurations;
using N5.PermissionsManager.API.Modulo.Permissions;
using N5.PermissionsManager.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N5.PermissionsManager.API
{
    public class Startup
    {
        private const string connectionstringkey = "ConnectionStrings:Premissions";
        private const string uriElasticsearchKey = "Elasticsearch:Uri";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureKafka();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "N5.PermissionsManager.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var container = app.ApplicationServices.GetAutofacRoot();

            InitializeModules(container);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "N5.PermissionsManager.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void InitializeModules(ILifetimeScope container) 
        {
            var connectionstring = Configuration[connectionstringkey];
            var uriElasticsearch = Configuration[uriElasticsearchKey];

            var eventbus = container.Resolve<IEventsBus>();

            PermissionsStartup.Initialize(connectionstring, uriElasticsearch, eventbus);
        }
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {

            containerBuilder.RegisterModule(new PermissionsAutofacModule());

            containerBuilder.RegisterType<KafkaEventsBus>().As<IEventsBus>().SingleInstance();
           
        }
    }
}
