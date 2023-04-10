//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Country.Shared.Models;

namespace D20Tek.CountryApi.Common
{
    public class MemoryReadRepository<T> : IReadRepository<T>
        where T : IdEntity, new()
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
