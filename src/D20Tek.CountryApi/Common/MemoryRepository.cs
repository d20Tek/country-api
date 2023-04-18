//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.CountryApi.Common
{
    public class MemoryRepository<T> : MemoryReadRepository<T>, IRepository<T>
        where T : IdEntity, new()
    {
        public Task<T> CreateItemAsync(T item)
        {
            if (item == null) throw new ArgumentNullException("item");

            Items.Add(item);
            return Task.FromResult(item);
        }

        public async Task<T> UpdateItemAsync(T item)
        {
            if (item == null) throw new ArgumentNullException("item");

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
            var existingItem = await GetItemByIdAsync(itemId);
            if (existingItem != null)
            {
                Items.Remove(existingItem);
            }

            return existingItem ?? new T();
        }
    }
}
