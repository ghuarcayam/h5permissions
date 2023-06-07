using Dapper;
using N5.BuildingBlocks.Application.Data;
using N5.PermissionsManager.Application.Configuration.Query;
using N5.PermissionsManager.Application.GetSinglePermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.GetPermissionTypes
{
    internal class GetPermissionTypesQueryHandler : IQueryHandler<GetPermissionTypesQuery, ResultPermissionTypesDto>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;
        public GetPermissionTypesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<ResultPermissionTypesDto> Handle(GetPermissionTypesQuery request, CancellationToken cancellationToken)
        {
            using (var connection = sqlConnectionFactory.CreateNewConnection())
            {
                string query = "       SELECT  A.ID, " +
                             "               A.Descripcion " +
                             "       FROM  " +
                             "                   [PermissionTypes] A (NOLOCK) ";
                             
                var result = await connection
                                    .QueryAsync<ResultPermissionTypesDto.PermissionType>
                                    (query);
                return new ResultPermissionTypesDto() { Items = result };
            }
        }
    }

}
