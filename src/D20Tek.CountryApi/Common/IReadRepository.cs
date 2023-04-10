//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Country.Shared.Models;

namespace D20Tek.CountryApi.Common
{
    public interface IReadRepository<T>
        where T : IdEntity, new()
    {
        Task<IList<T>> GetItemsAsync();

        Task<T> GetItemByIdAsync(string itemId);
    }
}
