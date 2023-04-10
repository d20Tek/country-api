//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Country.Shared.Models;
using D20Tek.CountryApi.Common;
using Microsoft.AspNetCore.Mvc;

namespace D20Tek.CountryApi.Controllers
{
    [Route("api/v1/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IRepository<CountryModel> _repository;

        public CountriesController(IRepository<CountryModel> repository)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(nameof(repository));
            _repository = repository;
        }

        // GET: api/countries
        [HttpGet]
        public async Task<IEnumerable<CountryModel>> Get()
        {
            return await _repository.GetItemsAsync();
        }

        // GET api/countries/5
        [HttpGet("{id}")]
        public async Task<CountryModel> Get(string id)
        {
            return await _repository.GetItemByIdAsync(id);
        }

        // POST api/countries
        [HttpPost]
        public async Task<CountryModel> Post([FromBody] CountryModel value)
        {
            return await _repository.CreateItemAsync(value);
        }

        // PUT api/countries/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CountryModel>> Put(string id, [FromBody] CountryModel value)
        {
            if (id != value.Id) return BadRequest();

            return await _repository.UpdateItemAsync(value);
        }

        // DELETE api/countries/5
        [HttpDelete("{id}")]
        public async Task<CountryModel> Delete(string id)
        {
            return await _repository.DeleteItemAsync(id);
        }
    }
}
