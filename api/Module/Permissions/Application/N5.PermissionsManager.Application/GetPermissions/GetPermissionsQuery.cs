using N5.PermissionsManager.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.GetPermissions
{
    public class GetPermissionsQuery: IQuery<DtoResultPermissions>
    {
        public GetPermissionsQuery(int startAt, int pageSize)
        {
            StartAt= startAt;
            PageSize = pageSize;
        }

        public int StartAt { get; }
        public int PageSize { get; }
    }
}
