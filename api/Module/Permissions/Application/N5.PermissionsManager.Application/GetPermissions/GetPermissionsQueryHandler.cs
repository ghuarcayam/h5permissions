using N5.BuildingBlocks.Application.Data;
using N5.PermissionsManager.Application.Configuration.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
namespace N5.PermissionsManager.Application.GetPermissions
{
    internal class GetPermissionsQueryHandler : IQueryHandler<GetPermissionsQuery, DtoResultPermissions>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;
        public GetPermissionsQueryHandler(ISqlConnectionFactory sqlConnectionFactory) 
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<DtoResultPermissions> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            
            using (var connection = sqlConnectionFactory.CreateNewConnection()) 
            {
                string query = "SELECT TOP (@PageSize) R.* " +
                             "   FROM ( " +
                             "       SELECT  A.ID, " +
                             "               A.NombreEmpleado, " +
                             "               A.ApellidoEmpleado, " +
                             "               A.TipoPermiso, " +
                             "               B.Descripcion TipoPermisoDescripcion, " +
                             "               A.FechaPermiso, " +
                             "               ROW_NUMBER() OVER(ORDER BY A.ID DESC) AS RowNumber " +
                             "       FROM  " +
                             "                   [Permissions] A (NOLOCK) " +
                             "       INNER JOIN  [PermissionTypes] (NOLOCK) B ON A.TipoPermiso = B.ID) R " +
                             "   WHERE  @StartAt <= R.RowNumber " +
                             "   ORDER BY RowNumber ";
                var result =await  connection
                                    .QueryAsync<DtoResultPermissions.ItemPermission>
                                    (query, new { @StartAt = request.StartAt, @PageSize = request.PageSize });
                return new() { Items = result };
            }
        }
    }
}
