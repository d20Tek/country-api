//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Country.Shared.Models;

namespace D20Tek.CountryApi.Common
{
    public interface IRepository<T> : IReadRepository<T>
        where T : IdEntity, new()
    {
        Task<T> CreateItemAsync(T item);

        Task<T> UpdateItemAsync(T item);

        Task<T> DeleteItemAsync(string itemId);
    }
}
