using N5.BuildingBlocks.Application.Outbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Infrastructure.Outbox
{
    public class OutboxAccessorMemory : IOutbox
    {
        List<OutboxMessage> outboxStore;
        public OutboxAccessorMemory() 
        {
            outboxStore = new ();
        }
        public void Add(OutboxMessage message)
        {
            outboxStore.Add( message);
        }

        public void Clear() { outboxStore.Clear(); }

        public IEnumerable<OutboxMessage> GetAll() 
        {
            return outboxStore.ToArray();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
