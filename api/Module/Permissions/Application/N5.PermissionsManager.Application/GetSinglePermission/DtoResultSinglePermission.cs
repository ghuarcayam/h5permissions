using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.GetSinglePermission
{
    public class DtoResultSinglePermission
    {
        public int ID { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int IdTipoPermiso { get; set; }
        public string DescripcionTipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }
    }
}
