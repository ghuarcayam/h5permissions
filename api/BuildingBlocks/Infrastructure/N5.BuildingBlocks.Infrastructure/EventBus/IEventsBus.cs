using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.BuildingBlocks.Infrastructure.EventBus
{
    public interface IEventsBus: IDisposable
    {
        Task Publish<T>(T @event, CancellationToken cancellationToken= default);
            
    }
}
