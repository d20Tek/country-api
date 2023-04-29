//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Services.Core
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityIdName, object entityIdValue, Exception? innerException = null)
            : base($"Entity with {entityIdName} = {entityIdValue} was not found in repository.", innerException)
        {
            EntityIdName = entityIdName;
            EntityIdValue = entityIdValue;
        }

        public string EntityIdName { get; private set; }

        public object EntityIdValue { get; private set; }
    }
}
