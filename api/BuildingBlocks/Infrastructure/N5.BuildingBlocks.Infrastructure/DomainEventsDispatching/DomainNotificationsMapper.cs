﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public class DomainNotificationsMapper : IDomainNotificationsMapper
    {
        private readonly BiDictionary<string, Type> _domainNotificationsMap;

        public DomainNotificationsMapper(BiDictionary<string, Type> domainNotificationsMap)
        {
            _domainNotificationsMap = domainNotificationsMap;
        }

        public string GetName(Type type)
        {
            return _domainNotificationsMap.TryGetBySecond(type, out var name) ? name : null;
        }

        public Type GetType(string name)
        {
            return _domainNotificationsMap.TryGetByFirst(name, out var type) ? type : null;
        }
    }
}
