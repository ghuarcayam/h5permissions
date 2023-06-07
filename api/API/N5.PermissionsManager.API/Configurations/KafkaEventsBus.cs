using MassTransit;
using N5.BuildingBlocks.Infrastructure.EventBus;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.API.Configurations
{
    public class KafkaEventsBus : IEventsBus
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public KafkaEventsBus(IPublishEndpoint _publishEndpoint) 
        {
            this._publishEndpoint = _publishEndpoint;
        }
        public async Task Publish<T>(T @event, CancellationToken cancellationToken = default)
        {
             await this._publishEndpoint.Publish(@event);
        }

        public void Dispose()
        {

        }
    }
}
