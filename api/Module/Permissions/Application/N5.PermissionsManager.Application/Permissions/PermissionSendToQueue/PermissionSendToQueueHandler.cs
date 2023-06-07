using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.Permissions.PermissionSendToQueue
{
    internal class PermissionSendToQueueHandler :
        INotificationHandler<PermissionCreatedSendToQueueNotification>,
        INotificationHandler<PermissionGotSendToQueueNotification>,
        INotificationHandler<PermissionModifiedSendToQueueNotification>
    {
        private readonly IPublisherActionPermissionMessage publisherActionPermissionMessage;
        public PermissionSendToQueueHandler(IPublisherActionPermissionMessage publisherActionPermissionMessage) 
        {
            this.publisherActionPermissionMessage = publisherActionPermissionMessage;
        }
        public async Task Handle(PermissionCreatedSendToQueueNotification notification, CancellationToken cancellationToken)
        {
             await publisherActionPermissionMessage.SendAync(NotificationPermission.request, cancellationToken);
        }

        public async Task Handle(PermissionModifiedSendToQueueNotification notification, CancellationToken cancellationToken)
        {
             await publisherActionPermissionMessage.SendAync(NotificationPermission.Modify, cancellationToken);
        }

        public async Task Handle(PermissionGotSendToQueueNotification notification, CancellationToken cancellationToken)
        {
             await publisherActionPermissionMessage.SendAync(NotificationPermission.Get, cancellationToken);
        }
    }
}
