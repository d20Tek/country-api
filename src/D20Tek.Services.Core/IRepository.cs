//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Services.Core
{
    public interface IRepository<T> : IReadRepository<T>
        where T : Entity, new()
    {
        Task<T> CreateItemAsync(T item);

        Task<T> UpdateItemAsync(T item);

        Task<T?> DeleteItemAsync(string itemId);
    }
}
