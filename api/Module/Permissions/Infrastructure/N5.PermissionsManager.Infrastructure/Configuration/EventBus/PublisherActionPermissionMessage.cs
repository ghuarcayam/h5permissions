using N5.BuildingBlocks.Infrastructure.EventBus;
using N5.PermissionsManager.Application.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Infrastructure.Configuration.EventBus
{
    internal class PublisherActionPermissionMessage : IPublisherActionPermissionMessage
    {
        private readonly IEventsBus eventsBus;
        public PublisherActionPermissionMessage(IEventsBus eventsBus)
        {
            this.eventsBus = eventsBus;
        }
        public Task SendAync(NotificationPermission notificationPermission, CancellationToken cancellationToken)
        {
            return this.eventsBus.Publish(notificationPermission, cancellationToken);
        }
    }
}
