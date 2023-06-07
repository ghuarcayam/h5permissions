using N5.BuildingBlocks.Application.Events;
using N5.PermissionsManager.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.Permissions.PermissionSyncWithElasticsearch
{
    public class PermissionCreatedSyncWithElasticsearchNotification : DomainNotificationBase<PremissionCreatedEvent>
    {
        public PermissionCreatedSyncWithElasticsearchNotification(PremissionCreatedEvent domainEvent, Guid id) : base(domainEvent, id)
        {
        }
    }
}
