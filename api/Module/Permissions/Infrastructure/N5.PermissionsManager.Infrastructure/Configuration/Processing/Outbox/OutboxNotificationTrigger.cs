using MediatR;
using N5.BuildingBlocks.Application.Outbox;
using N5.PermissionsManager.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Infrastructure.Configuration.Processing.Outbox
{
    internal class OutboxNotificationTrigger : IOutboxNotificationTrigger
    {
        private readonly IOutbox outbox;
        private readonly IMediator mediator;
        public OutboxNotificationTrigger(IOutbox outbox, IMediator mediator) 
        {
            this.outbox = outbox;
            this.mediator = mediator;
        }
        public async Task PublishAync(CancellationToken cancellationToken)
        {
            var messages = outbox.GetAll();
            foreach (var message in messages)
            {
                await mediator.Publish(message.Data, cancellationToken);
            }
        }
    }
}
