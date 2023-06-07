using MediatR.NotificationPublishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.BuildingBlocks.Application.Outbox
{
    public interface IOutboxNotificationTrigger
    {
        Task PublishAync(CancellationToken cancellationToken);
    }
}
