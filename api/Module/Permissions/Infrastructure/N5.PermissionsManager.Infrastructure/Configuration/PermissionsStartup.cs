using Autofac;
using Autofac.Core;
using N5.BuildingBlocks.Infrastructure;
using N5.BuildingBlocks.Infrastructure.EventBus;
using N5.PermissionsManager.Application.Permissions.PermissionSendToQueue;
using N5.PermissionsManager.Application.Permissions.PermissionSyncWithElasticsearch;
using N5.PermissionsManager.Infrastructure.Configuration.DataAccess;
using N5.PermissionsManager.Infrastructure.Configuration.EventBus;
using N5.PermissionsManager.Infrastructure.Configuration.Mediation;
using N5.PermissionsManager.Infrastructure.Configuration.Processing;
using N5.PermissionsManager.Infrastructure.Configuration.Processing.Outbox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Infrastructure.Configuration
{
    public static class PermissionsStartup
    {
        public static Autofac.IContainer _container;

        public static void Initialize(string connectionString, string uriElasticsearch, IEventsBus eventBus) 
        {
            ConfigureCompositionRoot(connectionString, uriElasticsearch, eventBus);
        }

        private static void ConfigureCompositionRoot(
            string connectionString, string uriElasticsearch, IEventsBus eventBus)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new DataAccessModule(connectionString));
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventBusModule(eventBus, uriElasticsearch));


            var domainNotificationsMap = new BiDictionary<string, Type>();
            domainNotificationsMap.Add(nameof(PermissionCreatedSendToQueueNotification), typeof(PermissionCreatedSendToQueueNotification));
            domainNotificationsMap.Add(nameof(PermissionGotSendToQueueNotification), typeof(PermissionGotSendToQueueNotification));
            domainNotificationsMap.Add(nameof(PermissionModifiedSendToQueueNotification), typeof(PermissionModifiedSendToQueueNotification));
            domainNotificationsMap.Add(nameof(PermissionCreatedSyncWithElasticsearchNotification), typeof(PermissionCreatedSyncWithElasticsearchNotification));
            domainNotificationsMap.Add(nameof(PermissionGotSyncWithElasticsearchNotification), typeof(PermissionGotSyncWithElasticsearchNotification));
            domainNotificationsMap.Add(nameof(PermissionModifiedSyncWithElasticsearchNotification), typeof(PermissionModifiedSyncWithElasticsearchNotification));


            containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));

            _container = containerBuilder.Build();

            PermissionsCompositionRoot.SetContainer(_container);
        }
    }
}
