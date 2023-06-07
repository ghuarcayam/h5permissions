using N5.BuildingBlocks.Domain;
using N5.PermissionsManager.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace N5.PermissionsManager.Domain
{
    public class Permission: Entity, IAggregateRoot
    {
        int _id;
        Person _person;
        PermissionType _permissiontype;
        DateTime _fechaPermiso;
        int? _tipoPermisoId;

        private Permission() 
        {
        
        }
        public Permission(PermissionType permissiontype, Person person, DateTime fechaPermiso)
        {
            
            _permissiontype = permissiontype;
            _fechaPermiso = fechaPermiso;
            _person = person;
            _tipoPermisoId = permissiontype != null || permissiontype.Id<0 ? permissiontype.Id: _tipoPermisoId;
            this.AddDomainEvent(new PremissionCreatedEvent(this));
        }

        public int Id { get => _id; private set => _id = value; }
        
        public PermissionType Permissiontype { get => _permissiontype; private set => _permissiontype = value; }

        public int? TipoPermisoId { get => _tipoPermisoId; private set => _tipoPermisoId = value; }
        public DateTime FechaPermiso { get => _fechaPermiso;  }
        public Person Person { get => this._person; }

        public void SetValues(Person person, PermissionType permissiontype, DateTime fechaPermiso) 
        {
            List<Tuple<dynamic, dynamic>> values = new()
            {
                new Tuple<dynamic, dynamic>(_tipoPermisoId.HasValue? _tipoPermisoId.Value: default(int), _permissiontype.Id),
                new Tuple<dynamic, dynamic>(_permissiontype, permissiontype),
                new Tuple<dynamic, dynamic>(_fechaPermiso, fechaPermiso),
                new Tuple<dynamic, dynamic>(_person, person)
                
            };

            _person = person;
            _permissiontype = permissiontype;
            _fechaPermiso = fechaPermiso;

            
            if (values.Any(x => x.Item1 != x.Item2))
                AddDomainEvent(new PermissionModifiedEvent(TipoPermisoId.Value, this._id, _person.NombreEmpleado, _person.ApellidoEmpleado, fechaPermiso));

        }
    }
}
