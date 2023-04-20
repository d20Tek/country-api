//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.CountryApi.Contracts
{
    public class CountryResponse
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string OfficialName { get; set; } = string.Empty;

        public string Alpha2Code { get; set; } = string.Empty;

        public string Alpha3Code { get; set; } = string.Empty;

        public string NumericCode { get; set; } = string.Empty;
    }
}
