//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Services.Core
{
    public interface IRequestResponseConverter<TRequest, TResponse, TEntity>
        where TRequest : new()
        where TResponse : new()
        where TEntity : Entity, new()
    {
        public TEntity FromRequest(TRequest requestModel);

        public TResponse? ToResponse(TEntity entity);
    }
}
