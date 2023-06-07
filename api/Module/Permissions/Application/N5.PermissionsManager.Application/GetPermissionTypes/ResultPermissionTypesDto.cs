using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.GetPermissionTypes
{
    public class ResultPermissionTypesDto
    {
        public IEnumerable<PermissionType> Items { get; set; }
        public class PermissionType 
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
        }
    }
}
