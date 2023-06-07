using Dapper;
using N5.BuildingBlocks.Application.Data;
using N5.PermissionsManager.Application.Configuration.Query;
using N5.PermissionsManager.Application.GetPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.GetSinglePermission
{
    internal class GetSinglePermissionQueryHandler : IQueryHandler<GetSinglePermissionQuery, DtoResultSinglePermission>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;
        public GetSinglePermissionQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<DtoResultSinglePermission> Handle(GetSinglePermissionQuery request, CancellationToken cancellationToken)
        {
            using (var connection = sqlConnectionFactory.CreateNewConnection())
            {
                string query = "       SELECT  A.ID, " +
                             "               A.NombreEmpleado, " +
                             "               A.ApellidoEmpleado, " +
                             "               A.TipoPermiso IdTipoPermiso, " +
                             "               B.Descripcion DescripcionTipoPermiso, " +
                             "               A.FechaPermiso  " +
                             "       FROM  " +
                             "                   [Permissions] A (NOLOCK) " +
                             "       INNER JOIN  [PermissionTypes] (NOLOCK) B ON A.TipoPermiso = B.ID" +
                             "       WHERE A.ID = @Id";
                var result = await connection
                                    .QueryAsync<DtoResultSinglePermission>
                                    (query, new { request.Id});
                return result.FirstOrDefault();
            }
        }
    }
}
