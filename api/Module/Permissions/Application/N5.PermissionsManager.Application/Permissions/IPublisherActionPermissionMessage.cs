using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.Permissions
{
    public interface IPublisherActionPermissionMessage
    {
        Task SendAync(NotificationPermission notificationPermission, CancellationToken cancellationToken);
    }

    public class NotificationPermission
    {
        private NotificationPermission(string operationName)
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }

        public string OperationName { get; }

        public static NotificationPermission Modify = new NotificationPermission("Modify");
        public static NotificationPermission request = new NotificationPermission("Request");
        public static NotificationPermission Get = new NotificationPermission("Get");
    }
}
