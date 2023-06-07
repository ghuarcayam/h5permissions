using Microsoft.EntityFrameworkCore;
using N5.BuildingBlocks.Application.Outbox;
using N5.BuildingBlocks.Infrastructure.DomainEventsDispatching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.BuildingBlocks.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;
        private readonly IOutboxNotificationTrigger outboxNotificationTrigger;
        public UnitOfWork(
            DbContext context,
           IDomainEventsDispatcher domainEventsDispatcher,
           IOutboxNotificationTrigger outboxNotificationTrigger)
        {
            this._context = context;
            this._domainEventsDispatcher = domainEventsDispatcher;
            this.outboxNotificationTrigger = outboxNotificationTrigger;
        }

        public async Task<int> CommitAsync(
            CancellationToken cancellationToken = default,
            Guid? internalCommandId = null)
        {
            await this._domainEventsDispatcher.DispatchEventsAsync();
            
            var result = await _context.SaveChangesAsync(cancellationToken);

            //await outboxNotificationTrigger.PublishAync(cancellationToken);

            return result;

        }
    }
}
