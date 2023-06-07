using Confluent.Kafka;
using N5.BuildingBlocks.Infrastructure.EventBus;
using N5.PermissionsManager.Application.Permissions;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Infrastructure.Configuration.EventBus
{
    public class ElasticsearchIndexPush : IESIndexPush
    {
        private readonly ElasticClient elasticClient;
        public const string IndexName = "permission_index";
        public ElasticsearchIndexPush(ElasticClient elasticClient) 
        {
            this.elasticClient = elasticClient;
            InitializeIndex();
        }
        public async Task InsertAsync(IndexESPremission premission, CancellationToken cancellationToken)
        {
            await elasticClient.IndexDocumentAsync(premission, cancellationToken);
        }

        private void InitializeIndex()
        {
            if (!elasticClient.Indices.Exists(IndexName).Exists)
            {
                var createIndexResponse = elasticClient.Indices.Create(IndexName, c => c
                    .Map<IndexESPremission>(m => m.AutoMap())
                );

            }
        }
    }
}
