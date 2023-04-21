//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.CountryApi.Contracts;
using D20Tek.Services.Core;

namespace D20Tek.CountryApi.Entities.Converters
{
    internal class CountryEntityConverter : IRequestResponseConverter<CountryRequest, CountryResponse, CountryEntity>
    {
        public CountryEntity FromRequest(CountryRequest requestModel)
        {
            return new CountryEntity
            {
                Name = requestModel.Name,
                OfficialName = requestModel.OfficialName,
                Alpha2Code = requestModel.Alpha2Code,
                Alpha3Code = requestModel.Alpha3Code,
                NumericCode = requestModel.NumericCode,
            };
        }

        public CountryResponse ToResponse(CountryEntity entity)
        {
            return new CountryResponse
            {
                Name = entity.Name,
                OfficialName = entity.OfficialName,
                Alpha2Code = entity.Alpha2Code,
                Alpha3Code = entity.Alpha3Code,
                NumericCode = entity.NumericCode,
                Id = entity.Id,
            };
        }
    }
}
