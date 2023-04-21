//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Services.Core
{
    public interface IReadRepository<T>
        where T : Entity, new()
    {
        Task<IList<T>> GetItemsAsync();

        Task<T> GetItemByIdAsync(string itemId);
    }
}
