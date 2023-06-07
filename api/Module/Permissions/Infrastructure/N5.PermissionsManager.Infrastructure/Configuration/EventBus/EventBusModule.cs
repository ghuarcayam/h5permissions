using Autofac;
using Confluent.Kafka;
using MassTransit;
using MassTransit.KafkaIntegration;
using Microsoft.EntityFrameworkCore;
using N5.BuildingBlocks.Infrastructure.EventBus;
using N5.PermissionsManager.Application.Permissions;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Infrastructure.Configuration.EventBus
{
    internal class EventBusModule: Module
    {
        private readonly IEventsBus eventsBus;
        private readonly string uriElasticsearch;
        public EventBusModule(IEventsBus eventsBus, string uriElasticsearch) 
        {
            this.eventsBus = eventsBus;
            this.uriElasticsearch = uriElasticsearch;
        }
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterInstance(eventsBus).AsSelf().AsImplementedInterfaces().SingleInstance();

            builder.RegisterType<ElasticsearchIndexPush>().As<IESIndexPush>().InstancePerLifetimeScope();
            builder.RegisterType<PublisherActionPermissionMessage>().As<IPublisherActionPermissionMessage>().InstancePerLifetimeScope();
            builder.Register(c => 
            {
                var settings = new ConnectionSettings(new Uri(uriElasticsearch))
                .DefaultIndex(ElasticsearchIndexPush.IndexName);
                return  new ElasticClient(settings);
            })
            .AsSelf()
            .InstancePerLifetimeScope();
        }
    }
}
