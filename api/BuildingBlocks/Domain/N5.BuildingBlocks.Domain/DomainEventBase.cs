﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.BuildingBlocks.Domain
{
    public class DomainEventBase : IDomainEvent
    {
        public Guid Id { get; }

        public DateTime OccurredOn { get; }

        public DomainEventBase()
        {
            this.Id = Guid.NewGuid();
            this.OccurredOn = DateTime.UtcNow;
        }
    }
}
