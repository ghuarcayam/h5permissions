using N5.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Domain
{
    public class Person : ValueObject
    {

        public static Person CreateNew(string nombreEmpleado, string apellidoEmpleado) 
        {
            return new(nombreEmpleado, apellidoEmpleado);
        }
        private Person(string nombreEmpleado, string apellidoEmpleado)
        {
            NombreEmpleado = nombreEmpleado;
            ApellidoEmpleado = apellidoEmpleado;
        }

        public string NombreEmpleado { get; }
        public string ApellidoEmpleado { get;}
    }
}
