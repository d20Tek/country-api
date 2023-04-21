//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Services.Core;

namespace D20Tek.CountryApi.Entities
{
    public class CountryEntity : Entity
    {
        public override string Id => Alpha3Code;

        public string Name { get; set; } = string.Empty;

        public string OfficialName { get; set; } = string.Empty;

        public string Alpha2Code { get; set; } = string.Empty;

        public string Alpha3Code { get; set; } = string.Empty;

        public string NumericCode { get; set; } = string.Empty;
    }
}
