﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public interface IDomainNotificationsMapper
    {
        string GetName(Type type);

        Type GetType(string name);
    }
}
