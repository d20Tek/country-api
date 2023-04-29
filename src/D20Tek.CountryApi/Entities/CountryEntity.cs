//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Services.Core;

namespace D20Tek.CountryApi.Entities
{
    public class CountryEntity : Entity
    {
        public override string Id => Alpha3Code;

        public string Name { get; init; } = string.Empty;

        public string OfficialName { get; init; } = string.Empty;

        public string Alpha2Code { get; init; } = string.Empty;

        public string Alpha3Code { get; init; } = string.Empty;

        public string NumericCode { get; init; } = string.Empty;
    }
}
