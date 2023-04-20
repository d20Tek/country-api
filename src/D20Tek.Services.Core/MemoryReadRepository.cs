//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Services.Core
{
    public class MemoryReadRepository<T> : IReadRepository<T>
        where T : Entity, new()
    {
        protected IList<T> Items { get; } = new List<T>();

        public Task<IList<T>> GetItemsAsync()
        {
            return Task.FromResult(Items);
        }

        public Task<T> GetItemByIdAsync(string itemId)
        {
            return Task.FromResult(Items.First(i => i.Id == itemId));
        }
    }
}
