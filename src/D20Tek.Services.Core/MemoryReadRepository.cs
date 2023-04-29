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

        public async Task<T> GetItemByIdAsync(string itemId)
        {
            var result = await TryGetItemByIdAsync(itemId) ?? 
                throw new EntityNotFoundException("Id", itemId);

            return result;
        }

        protected Task<T?> TryGetItemByIdAsync(string itemId)
        {
            var result = Items.FirstOrDefault(i => i.Id == itemId);
            return Task.FromResult(result);
        }
    }
}
