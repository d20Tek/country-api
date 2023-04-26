//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Services.Core.UnitTests.Fakes;
using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Services.Core.UnitTests
{
    [TestClass]
    public class MemoryRepositoryTests
    {
        [TestMethod]
        public async Task CreateItem_WithValidEntity()
        {
            // arrange
            var newEntity = new TestEntity { EntityId = "foo", Name = "bar", Value = 3 };
            var repo = new TestRepository();

            // act
            var result = await repo.CreateItemAsync(newEntity);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual("foo", result.EntityId);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityAlreadyExistsException))]
        [ExcludeFromCodeCoverage]
        public async Task UpdateItem_WithExistingEntityId()
        {
            // arrange
            var entities = new List<TestEntity>
            {
                new TestEntity { EntityId = "test1", Name = "Test1", Value = 1 },
            };
            var repo = new TestRepository(entities);

            var newEntity = new TestEntity { EntityId = "test1", Name = "bar", Value = 3 };

            // act
            var result = await repo.CreateItemAsync(newEntity);
        }

        [TestMethod]
        public async Task UpdateItem_WithValidEntity()
        {
            // arrange
            var entities = new List<TestEntity>
            {
                new TestEntity { EntityId = "test1", Name = "Test1", Value = 1 },
            };
            var repo = new TestRepository(entities);

            var updatedEntity = new TestEntity { EntityId = "test1", Name = "bar", Value = 3 };

            // act
            var result = await repo.UpdateItemAsync(updatedEntity);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test1", result.EntityId);
            Assert.AreEqual("bar", result.Name);
            Assert.AreEqual(3, result.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        [ExcludeFromCodeCoverage]
        public async Task UpdateItem_WithNonExistingEntity()
        {
            // arrange
            var repo = new TestRepository();

            var updatedEntity = new TestEntity { EntityId = "test1", Name = "bar", Value = 3 };

            // act
            var result = await repo.UpdateItemAsync(updatedEntity);
        }

        [TestMethod]
        public async Task DeleteItem_WithValidEntity()
        {
            // arrange
            var entities = new List<TestEntity>
            {
                new TestEntity { EntityId = "test1", Name = "Test1", Value = 1 },
            };
            var repo = new TestRepository(entities);

            // act
            var result = await repo.DeleteItemAsync("test1");

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test1", result.EntityId);

            var items = await repo.GetItemsAsync();
            Assert.IsFalse(items.Any());
        }

        [TestMethod]
        public async Task DeleteItem_WithNonExistingEntity()
        {
            // arrange
            var repo = new TestRepository();

            // act
            var result = await repo.DeleteItemAsync("test1");

            // assert
            Assert.IsNull(result);
        }
    }
}
