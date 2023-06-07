using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.Permissions.PermissionSyncWithElasticsearch
{
    internal class PermissionSyncWithElasticsearchHandler :
        INotificationHandler<PermissionCreatedSyncWithElasticsearchNotification>,
        INotificationHandler<PermissionGotSyncWithElasticsearchNotification>,
        INotificationHandler<PermissionModifiedSyncWithElasticsearchNotification>
    {
        private readonly IESIndexPush eSIndexPush;
        public PermissionSyncWithElasticsearchHandler(IESIndexPush eSIndexPush) 
        {
            this.eSIndexPush = eSIndexPush;
        }   
        public async Task Handle(PermissionCreatedSyncWithElasticsearchNotification notification, CancellationToken cancellationToken)
        {
            var domain = notification.DomainEvent;
            var notf = new IndexESPremission() 
            {
                Id = domain.DomainId,
                ApellidoEmpleado= domain.ApellidoEmpleado,
                FechaPermiso= domain.FechaPermiso,
                NombreEmpleado= domain.NombreEmpleado,
                TipoPermiso= domain.TipoPermiso
            };
            await this.eSIndexPush.InsertAsync(notf, cancellationToken);
        }

        public async Task Handle(PermissionGotSyncWithElasticsearchNotification notification, CancellationToken cancellationToken)
        {
            var domain = notification.DomainEvent;
            var notf = new IndexESPremission()
            {
                Id = domain.DomainId,
                ApellidoEmpleado = domain.ApellidoEmpleado,
                FechaPermiso = domain.FechaPermiso,
                NombreEmpleado = domain.NombreEmpleado,
                TipoPermiso = domain.TipoPermiso
            };
            await this.eSIndexPush.InsertAsync(notf, cancellationToken);
        }

        public async Task Handle(PermissionModifiedSyncWithElasticsearchNotification notification, CancellationToken cancellationToken)
        {
            var domain = notification.DomainEvent;
            var notf = new IndexESPremission()
            {
                Id = domain.DomainId,
                ApellidoEmpleado = domain.ApellidoEmpleado,
                FechaPermiso = domain.FechaPermiso,
                NombreEmpleado = domain.NombreEmpleado,
                TipoPermiso = domain.TipoPermiso
            };
            await this.eSIndexPush.InsertAsync(notf, cancellationToken);
        }
    }
}
