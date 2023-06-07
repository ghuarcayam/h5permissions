using N5.BuildingBlocks.Domain;
using N5.PermissionsManager.Domain.Events;
using NUnit.Framework;
using System;
using System.Linq;

namespace N5.PermissionsManager.Domain.UnitTests
{
    public class PermissionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreatePermission_IsSuccessful()
        {
            var permission = new Permission(new PermissionType("Type Test"), 
                                            Person.CreateNew("Name","Last Name"), 
                                            DateTime.Now);
            var permisionCreated = AssertPublishedDomainEvent<PremissionCreatedEvent>(permission);

            Assert.IsNotNull(permisionCreated);
        }

        [Test]
        public void ModifiedPermission_IsSuccessful() 
        {
            var permission = new Permission(new PermissionType("Type Test"),
                                            Person.CreateNew("Name", "Last Name"),
                                            DateTime.Now);
            permission.ClearDomainEvents();

            permission.SetValues(Person.CreateNew("Name Alter", "Last Name Alter"), permission.Permissiontype, permission.FechaPermiso);

            var permissionModified = AssertPublishedDomainEvent<PermissionModifiedEvent>(permission);

            Assert.IsNotNull(permissionModified);
        }

        [Test]
        public void NotModifiedPermission_IsSuccessful()
        {
            var permission = new Permission(new PermissionType("Type Test"),
                                            Person.CreateNew("Name", "Last Name"),
                                            DateTime.Now);
            permission.ClearDomainEvents();

            permission.SetValues(permission.Person, permission.Permissiontype, permission.FechaPermiso);

            

            Assert.IsTrue(!permission.DomainEvents.Any());
        }


        public static T AssertPublishedDomainEvent<T>(Entity aggregate)
            where T : IDomainEvent
        {
            var domainEvent = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().SingleOrDefault();

            if (domainEvent == null)
            {
                throw new Exception($"{typeof(T).Name} event not published");
            }

            return domainEvent;
        }
    }
}