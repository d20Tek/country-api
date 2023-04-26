//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.CountryApi.Contracts
{
    public class CountryRequest
    {
        public string Name { get; init; } = string.Empty;

        public string OfficialName { get; init; } = string.Empty;

        public string Alpha2Code { get; init; } = string.Empty;

        public string Alpha3Code { get; init; } = string.Empty;

        public string NumericCode { get; init; } = string.Empty;
    }
}
