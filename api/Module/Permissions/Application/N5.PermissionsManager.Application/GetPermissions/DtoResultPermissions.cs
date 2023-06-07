using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.GetPermissions
{
    public class DtoResultPermissions
    {
        public IEnumerable<ItemPermission> Items { get; set; }

        public DtoResultPermissions() 
        {
            Items = new List<ItemPermission>();
        }

        public class ItemPermission 
        {
            public int ID { get; set; }
            public string NombreEmpleado { get; set; }
            public string ApellidoEmpleado { get; set; }
            public int TipoPermiso { get; set; }
            public string TipoPermisoDescripcion { get; set; }
            public DateTime FechaPermiso { get; set; }
        }
    }
}
