//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Country.Shared.Models
{
    public class CountryModel : IdEntity
    {
        public override string Id => Alpha3Code;

        public string Name { get; set; } = string.Empty;

        public string OfficialName { get; set; } = string.Empty;

        public string Alpha2Code { get; set; } = string.Empty;

        public string Alpha3Code { get; set; } = string.Empty;

        public string NumericCode { get; set; } = string.Empty;
    }
}
