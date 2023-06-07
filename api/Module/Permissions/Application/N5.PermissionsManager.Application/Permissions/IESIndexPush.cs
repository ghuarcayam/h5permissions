using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.Permissions
{
    public interface IESIndexPush
    {
        Task InsertAsync(IndexESPremission premission, CancellationToken cancellationToken);
        
    }

    public class IndexESPremission 
    {
        public int TipoPermiso { get; set; }
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public DateTime FechaPermiso { get; set; }
    }
    
}
