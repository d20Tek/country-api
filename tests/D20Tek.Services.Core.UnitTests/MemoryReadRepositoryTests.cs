//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Services.Core.UnitTests.Fakes;

namespace D20Tek.Services.Core.UnitTests
{
    [TestClass]
    public class MemoryReadRepositoryTests
    {
        [TestMethod]
        public async Task GetItemsAsync_EmptyList()
        {
            // arrange
            var repo = new TestRepository();

            // act
            var results = await repo.GetItemsAsync();

            // assert
            Assert.IsNotNull(results);
            Assert.IsFalse(results.Any());
        }

        [TestMethod]
        public async Task GetItemsAsync_InitializedList()
        {
            // arrange
            var entities = new List<TestEntity>
            {
                new TestEntity { EntityId = "test1", Name = "Test1", Value = 1 },
                new TestEntity { EntityId = "test2", Name = "Test2", Value = 2 },
                new TestEntity { EntityId = "test3", Name = "Test3", Value = 3 },
            };
            var repo = new TestRepository(entities);

            // act
            var results = await repo.GetItemsAsync();

            // assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count());
            Assert.IsTrue(results.Any(p => p.Id == "test1"));
        }

        [TestMethod]
        public async Task GetItemByIdAsync_WithExpectedItem()
        {
            // arrange
            var entities = new List<TestEntity>
            {
                new TestEntity { EntityId = "test1", Name = "Test1", Value = 1 },
            };
            var repo = new TestRepository(entities);

            // act
            var result = await repo.GetItemByIdAsync("test1");

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test1", result.EntityId);
            Assert.AreEqual("Test1", result.Name);
            Assert.AreEqual(1, result.Value);
        }
    }
}