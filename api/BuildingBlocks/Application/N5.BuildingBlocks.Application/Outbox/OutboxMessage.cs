using N5.BuildingBlocks.Application.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.BuildingBlocks.Application.Outbox
{
    public class OutboxMessage
    {
        public Guid Id { get; set; }

        public DateTime OccurredOn { get; set; }

        public string Type { get; set; }

        public IDomainEventNotification Data { get; set; }

        public DateTime? ProcessedDate { get; set; }

        public OutboxMessage(Guid id, DateTime occurredOn, string type, IDomainEventNotification data)
        {
            this.Id = id;
            this.OccurredOn = occurredOn;
            this.Type = type;
            this.Data = data;
        }

        private OutboxMessage()
        {
        }
    }
}
