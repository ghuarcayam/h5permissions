using Autofac;
using N5.BuildingBlocks.Application.Events;
using N5.BuildingBlocks.Application.Outbox;
using N5.BuildingBlocks.Infrastructure.DomainEventsDispatching;
using N5.BuildingBlocks.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N5.PermissionsManager.Infrastructure.Outbox;
using N5.PermissionsManager.Application.Contract;

namespace N5.PermissionsManager.Infrastructure.Configuration.Processing.Outbox
{
    internal class OutboxModule : Module
    {
        private readonly BiDictionary<string, Type> _domainNotificationsMap;

        public OutboxModule(BiDictionary<string, Type> domainNotificationsMap)
        {
            _domainNotificationsMap = domainNotificationsMap;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OutboxAccessorMemory>()
                .As<IOutbox>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OutboxNotificationTrigger>()
                .As<IOutboxNotificationTrigger>()
                .InstancePerLifetimeScope();

            this.CheckMappings();

            builder.RegisterType<DomainNotificationsMapper>()
                .As<IDomainNotificationsMapper>()
                .WithParameter("domainNotificationsMap", _domainNotificationsMap)
                .SingleInstance();
        }

        private void CheckMappings()
        {
            var assemblyApplication = typeof(IPermissionsModule).Assembly;

            var domainEventNotifications = assemblyApplication
                .GetTypes()
                .Where(x => x.GetInterfaces().Contains(typeof(IDomainEventNotification)))
                .ToList();

            List<Type> notMappedNotifications = new List<Type>();
            foreach (var domainEventNotification in domainEventNotifications)
            {
                _domainNotificationsMap.TryGetBySecond(domainEventNotification, out var name);

                if (name == null)
                {
                    notMappedNotifications.Add(domainEventNotification);
                }
            }

            if (notMappedNotifications.Any())
            {
                throw new ApplicationException($"Domain Event Notifications {notMappedNotifications.Select(x => x.FullName).Aggregate((x, y) => x + "," + y)} not mapped");
            }
        }
    }
}
