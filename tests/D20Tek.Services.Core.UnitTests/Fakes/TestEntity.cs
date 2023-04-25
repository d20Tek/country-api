//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Services.Core;

namespace D20Tek.Services.Core.UnitTests.Fakes
{
    internal class TestEntity : Entity
    {
        public override string Id => EntityId;

        public string EntityId { get; init; } = string.Empty;

        public string Name { get; init; } = string.Empty;

        public int Value { get; init; }
    }
}
