//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Services.Core.UnitTests.Fakes
{
    internal class TestRepository : MemoryRepository<TestEntity>
    {
        public TestRepository()
        {
        }

        public TestRepository(IEnumerable<TestEntity> initialEntities)
        {
            ArgumentNullException.ThrowIfNull(nameof(initialEntities));

            foreach (var entity in initialEntities)
            {
                Items.Add(entity);
            }
        }
    }
}
