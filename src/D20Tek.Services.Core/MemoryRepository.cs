//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Services.Core
{
    public class MemoryRepository<T> : MemoryReadRepository<T>, IRepository<T>
        where T : Entity, new()
    {
        public async Task<T> CreateItemAsync(T item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            if ((await TryGetItemByIdAsync(item.Id)) != null)
            {
                throw new EntityAlreadyExistsException("Id", item.Id);
            }

            Items.Add(item);
            return item;
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

        public async Task<T?> DeleteItemAsync(string itemId)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(itemId, nameof(itemId));

            var existingItem = await TryGetItemByIdAsync(itemId);
            if (existingItem != null)
            {
                Items.Remove(existingItem);
            }

            return existingItem;
        }
    }
}
