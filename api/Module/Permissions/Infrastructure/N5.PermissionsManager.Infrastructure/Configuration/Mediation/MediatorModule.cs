using Autofac;
using MediatR.Pipeline;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using N5.PermissionsManager.Application.Contract;

namespace N5.PermissionsManager.Infrastructure.Configuration.Mediation
{
    internal class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly)
             .AsImplementedInterfaces()
             .InstancePerLifetimeScope();

            var openHandlerTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>),
                typeof(IValidator<>)
            };

            var assemblyApplication = typeof(IPermissionsModule).Assembly;

            foreach (var i in openHandlerTypes)
            {
                builder.RegisterAssemblyTypes(assemblyApplication)
                    .AsClosedTypesOf(i)
                    .AsImplementedInterfaces();
            }

            builder.RegisterType<ServiceProviderWrapper>()
            .As<IServiceProvider>()
            .InstancePerDependency()
            .IfNotRegistered(typeof(IServiceProvider))
            .InstancePerLifetimeScope();
        }
    }
}
