using Autofac;
using MediatR;
using N5.PermissionsManager.Application.Contract;
using N5.PermissionsManager.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace N5.PermissionsManager.Infrastructure
{
    public class PermissionsModule : IPermissionsModule
    {
        
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)
        {
            using (var scope = PermissionsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(command, cancellationToken);
            }
        }


        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        {
            using (var scope = PermissionsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query, cancellationToken);
            }
        }
    }
}
