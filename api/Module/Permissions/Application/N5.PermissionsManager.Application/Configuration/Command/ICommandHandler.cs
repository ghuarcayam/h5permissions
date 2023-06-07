using MediatR;
using N5.PermissionsManager.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.Configuration.Command
{
    public interface ICommandHandler<in TCommand, TResult> :
       IRequestHandler<TCommand, TResult>
       where TCommand : ICommand<TResult>
    {
    }
}
