//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Services.Core
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string entityIdName, object entityIdValue, Exception? innerException = null)
            : base($"Entity with {entityIdName} = {entityIdValue} already exists in this repository.", innerException)
        {
            EntityIdName = entityIdName;
            EntityIdValue = entityIdValue;
        }

        public string EntityIdName { get; init; }

        public object EntityIdValue { get; init; }
    }
}
