using N5.PermissionsManager.Application.Contract;
using N5.PermissionsManager.Application.GetPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.GetSinglePermission
{
    public class GetSinglePermissionQuery: IQuery<DtoResultSinglePermission>
    {
        public int Id { get; }
        public GetSinglePermissionQuery(int id) 
        {
            Id = id;
        }
    }
}
