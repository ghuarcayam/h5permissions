using Autofac;
using N5.PermissionsManager.Application.Contract;
using N5.PermissionsManager.Infrastructure;

namespace N5.PermissionsManager.API.Modulo.Permissions
{
    public class PermissionsAutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PermissionsModule>()
                .As<IPermissionsModule>()
                .InstancePerLifetimeScope();
        }
    }
}
