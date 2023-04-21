//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.CountryApi.Contracts;
using D20Tek.CountryApi.Entities;
using D20Tek.CountryApi.Entities.Converters;
using D20Tek.Services.Core;
using Microsoft.AspNetCore.Mvc;

namespace D20Tek.CountryApi.Controllers
{
    [Route("api/v1/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IRepository<CountryEntity> _repository;
        private readonly CountryEntityConverter _converter;

        public CountriesController(IRepository<CountryEntity> repository)
        {
            ArgumentNullException.ThrowIfNull(nameof(repository));
            _repository = repository;
            _converter = new CountryEntityConverter();
        }

        // GET: api/countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryResponse>>> GetCountries()
        {
            var countries = await _repository.GetItemsAsync();
            return Ok(countries.Select(c => _converter.ToResponse(c)));
        }

        // GET api/countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryResponse>> GetCountryById(string id)
        {
            var country = await _repository.GetItemByIdAsync(id);
            return Ok(_converter.ToResponse(country));
        }

        // POST api/countries
        [HttpPost]
        public async Task<ActionResult<CountryResponse>> CreateCountry([FromBody] CountryRequest value)
        {
            var entity = _converter.FromRequest(value);
            var createdCountry = await _repository.CreateItemAsync(entity);
            return CreatedAtAction(nameof(CreateCountry), createdCountry);
        }

        // PUT api/countries/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CountryResponse>> UpdateCountry(string id, [FromBody] CountryRequest value)
        {
            var entity = _converter.FromRequest(value);
            var updatedCountry = await _repository.UpdateItemAsync(entity);
            return Ok(updatedCountry);
        }

        // DELETE api/countries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CountryResponse>> DeleteCountry(string id)
        {
            var deletedCountry = await _repository.DeleteItemAsync(id);
            return Ok(_converter.ToResponse(deletedCountry));
        }
    }
}
