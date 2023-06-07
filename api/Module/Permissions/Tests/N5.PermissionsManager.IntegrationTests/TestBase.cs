using Dapper;
using N5.BuildingBlocks.Infrastructure.EventBus;
using N5.PermissionsManager.Application.Contract;
using N5.PermissionsManager.Infrastructure;
using N5.PermissionsManager.Infrastructure.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.IntegrationTests
{
    public class TestBase
    {
        protected string ConnectionString { get; private set; }

        protected IPermissionsModule PermissionsModule { get; private set; }

        protected MockBusService EventBus { get; private set; }

        [SetUp]
        public async Task BeforeEachTest() 
        {
            ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SLD_TRANSVERSAL;Data Source=.\\sqlexpress";

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                await ClearDatabase(sqlConnection);
            }
            EventBus = new MockBusService();
            PermissionsStartup.Initialize(ConnectionString, "http://localhost:9200", EventBus);
            PermissionsModule = new PermissionsModule();
        }
        private static async Task ClearDatabase(IDbConnection connection)
        {
            const string sql = "DELETE FROM [dbo].[Permissions] " +
                               "DELETE FROM [dbo].[PermissionTypes] ";

            await connection.ExecuteScalarAsync(sql);
        }
    }

    public class MockBusService : IEventsBus
    {
        public List<object> List { get; private set; }
        public MockBusService() 
        {
            List = new List<object>();
        }
        public void Dispose()
        {
            
        }

        public async Task Publish<T>(T @event, CancellationToken cancellationToken = default)
        {
            List.Add(@event);
        }
    }
}
