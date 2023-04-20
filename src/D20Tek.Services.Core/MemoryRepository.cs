//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Services.Core
{
    public class MemoryRepository<T> : MemoryReadRepository<T>, IRepository<T>
        where T : Entity, new()
    {
        public Task<T> CreateItemAsync(T item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            Items.Add(item);
            return Task.FromResult(item);
        }

        public async Task<T> UpdateItemAsync(T item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            var existingItem = await GetItemByIdAsync(item.Id);
            if (existingItem != null)
            {
                Items.Remove(existingItem);
                Items.Add(item);
            }

            return item;
        }

        public async Task<T> DeleteItemAsync(string itemId)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(itemId, nameof(itemId));

            var existingItem = await GetItemByIdAsync(itemId);
            if (existingItem != null)
            {
                Items.Remove(existingItem);
            }

            return existingItem ?? new T();
        }
    }
}
