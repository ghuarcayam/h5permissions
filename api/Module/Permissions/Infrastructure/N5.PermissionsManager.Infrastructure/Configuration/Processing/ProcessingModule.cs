using Autofac;
using MediatR.Pipeline;
using MediatR;
using N5.BuildingBlocks.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N5.BuildingBlocks.Infrastructure.DomainEventsDispatching;
using N5.BuildingBlocks.Application.Events;
using N5.PermissionsManager.Application.Contract;

namespace N5.PermissionsManager.Infrastructure.Configuration.Processing
{
    internal class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DomainEventsDispatcher>().As<IDomainEventsDispatcher>().InstancePerLifetimeScope();
            builder.RegisterType<DomainEventsAccessor>().As<IDomainEventsAccessor>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(UnitOfWorkCommandPipeBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestExceptionActionProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestExceptionProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));

            var assemblyApplication = typeof(IPermissionsModule).Assembly;

            builder.RegisterAssemblyTypes(assemblyApplication)
                .AsClosedTypesOf(typeof(IDomainEventNotification<>))
                .InstancePerDependency();
                
        }
    }
}
