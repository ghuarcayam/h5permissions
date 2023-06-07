using MediatR;
using N5.BuildingBlocks.Infrastructure;
using N5.PermissionsManager.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandPipeBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {

        private readonly IUnitOfWork unitOfWork;

        public UnitOfWorkCommandPipeBehavior(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var result = await next();


            await unitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}
