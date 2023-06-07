using N5.PermissionsManager.Application.GetPermissions;
using N5.PermissionsManager.Application.GetSinglePermission;
using N5.PermissionsManager.Application.ModifyPermission;
using N5.PermissionsManager.Application.RequestPermission;
using Nest;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace N5.PermissionsManager.IntegrationTests
{
    public class Tests: TestBase
    {
        
        [Test]
        public async Task RequestPermission_Test()
        {
            var result = await PermissionsModule.ExecuteCommandAsync(new 
                RequestPermissionCommand("Giancarlo", "Huarcaya", DateTime.Now, "Test", null));

            var permissionDto = await PermissionsModule.ExecuteQueryAsync(new GetSinglePermissionQuery(result.Id));

            Assert.IsNotNull(permissionDto);

        }

        [Test]
        public async Task ModifiedPermission_Test()
        {
            var result = await PermissionsModule.ExecuteCommandAsync(new
                RequestPermissionCommand("Giancarlo", "Huarcaya", DateTime.Now, "Test", null));

            await PermissionsModule.ExecuteCommandAsync(new
                ModifyPermissionCommand(result.Id, "Test", "Test", DateTime.Now, "Test", null));

            var permissionDto = await PermissionsModule.ExecuteQueryAsync(new GetSinglePermissionQuery(result.Id));

            Assert.IsTrue(permissionDto.NombreEmpleado == "Test");

        }
        [Test]
        public async Task PaginationPermission_Test() 
        {
            await PermissionsModule.ExecuteCommandAsync(new
                RequestPermissionCommand("Giancarlo", "Huarcaya", DateTime.Now, "Test", null));

            await PermissionsModule.ExecuteCommandAsync(new
                RequestPermissionCommand("Giancarlo", "Huarcaya", DateTime.Now, "Test", null));

            await PermissionsModule.ExecuteCommandAsync(new
                RequestPermissionCommand("Giancarlo", "Huarcaya", DateTime.Now, "Test", null));

            await PermissionsModule.ExecuteCommandAsync(new
                RequestPermissionCommand("Giancarlo", "Huarcaya", DateTime.Now, "Test", null));

            await PermissionsModule.ExecuteCommandAsync(new
                RequestPermissionCommand("Giancarlo", "Huarcaya", DateTime.Now, "Test", null));


            var result = await PermissionsModule.ExecuteQueryAsync(new GetPermissionsQuery(1, 5));

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Items);

            Assert.IsTrue(result.Items.Count() == 5);
        }
    }
}