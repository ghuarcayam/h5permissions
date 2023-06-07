using Autofac;
using Autofac.Core;
using MediatR;
using N5.BuildingBlocks.Application.Events;
using N5.BuildingBlocks.Application.Outbox;
using N5.BuildingBlocks.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly IMediator _mediator;

        private readonly ILifetimeScope _scope;

        private readonly IOutbox _outbox;

        private readonly IDomainEventsAccessor _domainEventsProvider;

        private readonly IDomainNotificationsMapper _domainNotificationsMapper;

        public DomainEventsDispatcher(
           IMediator mediator,
           ILifetimeScope scope,
           IOutbox outbox,
           IDomainEventsAccessor domainEventsProvider,
           IDomainNotificationsMapper domainNotificationsMapper)
        {
            _mediator = mediator;
            _scope = scope;
            _outbox = outbox;
            _domainEventsProvider = domainEventsProvider;
            _domainNotificationsMapper = domainNotificationsMapper;
        }
        public async Task DispatchEventsAsync()
        {
            var domainEvents = _domainEventsProvider.GetAllDomainEvents();

            var domainEventNotifications = new List<IDomainEventNotification<IDomainEvent>>();
            foreach (var domainEvent in domainEvents)
            {
                Type enumerableType = typeof(IEnumerable<>);
                Type domainEvenNotificationType = typeof(IDomainEventNotification<>);
                var domainNotificationWithGenericType = domainEvenNotificationType.MakeGenericType(domainEvent.GetType());
                var domainNotifications = _scope.ResolveOptional(enumerableType.MakeGenericType(domainNotificationWithGenericType), new List<Parameter>
                {
                    new NamedParameter("domainEvent", domainEvent),
                    new NamedParameter("id", domainEvent.Id)
                });
                
                if (domainNotifications != null)
                {
                    foreach (var domainNotification in domainNotifications as IEnumerable)
                    {
                        domainEventNotifications.Add(domainNotification as IDomainEventNotification<IDomainEvent>);
                    }
                    
                }
            }

            _domainEventsProvider.ClearAllDomainEvents();

            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }

            foreach (var domainEventNotification in domainEventNotifications)
            {
                var type = _domainNotificationsMapper.GetName(domainEventNotification.GetType());
                var data = domainEventNotification; //JsonConvert.SerializeObject(domainEventNotification, new JsonSerializerSettings
                //{
                //    ContractResolver = new AllPropertiesContractResolver()
                //});

                var outboxMessage = new OutboxMessage(
                    domainEventNotification.Id,
                    domainEventNotification.DomainEvent.OccurredOn,
                    type,
                    data);

                _outbox.Add(outboxMessage);
            }
        }
    }
}
