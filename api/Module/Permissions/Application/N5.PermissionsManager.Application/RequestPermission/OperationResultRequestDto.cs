using N5.PermissionsManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.RequestPermission
{
    public class OperationResultRequestDto
    {
        private readonly Permission permission;
        public OperationResultRequestDto(Permission permission ) 
        {
            this.permission = permission;
        }
        public int Id { get => permission.Id; }
    }
}
