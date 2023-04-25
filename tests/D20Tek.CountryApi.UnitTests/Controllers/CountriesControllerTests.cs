//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.CountryApi.Contracts;
using D20Tek.CountryApi.Controllers;
using D20Tek.CountryApi.Entities;
using D20Tek.CountryApi.UnitTests.Helpers;
using D20Tek.Services.Core;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace D20Tek.CountryApi.UnitTests.Controllers
{
    [TestClass]
    public class CountriesControllerTests
    {
        [TestMethod]
        public async Task GetCountries_EmptyList()
        {
            // arrange
            var mockRepo = new Mock<IRepository<CountryEntity>>();
            mockRepo.Setup(p => p.GetItemsAsync()).ReturnsAsync(new List<CountryEntity>());

            var controller = new CountriesController(mockRepo.Object);

            // act
            var result = await controller.GetCountries();

            // assert
            var value = ActionResultValidator.ValidateOkResultValue<IEnumerable<CountryResponse>>(result);
            Assert.IsFalse(value.Any());
        }

        [TestMethod]
        public async Task GetCountries_SimpleList()
        {
            // arrange
            var countries = new List<CountryEntity>
            {
                new CountryEntity { Name="Test1", Alpha3Code = "TS1" },
                new CountryEntity { Name="Test2", Alpha3Code = "TS2" },
                new CountryEntity { Name="Test3", Alpha3Code = "TS3" }
            };
            var mockRepo = new Mock<IRepository<CountryEntity>>();
            mockRepo.Setup(p => p.GetItemsAsync()).ReturnsAsync(countries);

            var controller = new CountriesController(mockRepo.Object);

            // act
            var result = await controller.GetCountries();

            // assert
            var value = ActionResultValidator.ValidateOkResultValue<IEnumerable<CountryResponse>>(result);
            Assert.AreEqual(3, value.Count());
        }

        [TestMethod]
        public async Task GetCountryById_FoundCountry()
        {
            // arrange
            var country = new CountryEntity
            {
                Name = "Test1",
                OfficialName = "Test 1",
                Alpha2Code = "T1",
                Alpha3Code = "TS1",
                NumericCode = "042",
            };
            var mockRepo = new Mock<IRepository<CountryEntity>>();
            mockRepo.Setup(p => p.GetItemByIdAsync(It.IsAny<string>())).ReturnsAsync(country);

            var controller = new CountriesController(mockRepo.Object);

            // act
            var result = await controller.GetCountryById("TS1");

            // assert
            var value = ActionResultValidator.ValidateOkResultValue<CountryResponse>(result);
            Assert.AreEqual("Test1", value.Name);
            Assert.AreEqual("Test 1", value.OfficialName);
            Assert.AreEqual("T1", value.Alpha2Code);
            Assert.AreEqual("TS1", value.Alpha3Code);
            Assert.AreEqual("042", value.NumericCode);
            Assert.AreEqual("TS1", value.Id);
        }

        [TestMethod]
        public async Task CreateCountry_WithValidRequest()
        {
            // arrange
            var country = new CountryEntity
            {
                Name = "Test2",
                OfficialName = "Test 2",
                Alpha2Code = "T2",
                Alpha3Code = "TS2",
                NumericCode = "043",
            };
            var mockRepo = new Mock<IRepository<CountryEntity>>();
            mockRepo.Setup(p => p.CreateItemAsync(It.IsAny<CountryEntity>())).ReturnsAsync(country);

            var controller = new CountriesController(mockRepo.Object);

            var request = new CountryRequest
            {
                Name = "Test2",
                OfficialName = "Test 2",
                Alpha2Code = "T2",
                Alpha3Code = "TS2",
                NumericCode = "043",
            };

            // act
            var result = await controller.CreateCountry(request);

            // assert
            var value = ActionResultValidator.ValidateCreatedAtResultValue<CountryResponse>(result);
            Assert.AreEqual("Test2", value.Name);
            Assert.AreEqual("TS2", value.Id);
        }

        [TestMethod]
        public async Task UpdateCountry_WithValidRequest()
        {
            // arrange
            var country = new CountryEntity
            {
                Name = "Test3",
                OfficialName = "Test 3",
                Alpha2Code = "T3",
                Alpha3Code = "TS3",
                NumericCode = "044",
            };
            var mockRepo = new Mock<IRepository<CountryEntity>>();
            mockRepo.Setup(p => p.UpdateItemAsync(It.IsAny<CountryEntity>())).ReturnsAsync(country);

            var controller = new CountriesController(mockRepo.Object);

            var request = new CountryRequest
            {
                Name = "Test3",
                OfficialName = "Test 3",
                Alpha2Code = "T3",
                Alpha3Code = "TS3",
                NumericCode = "044",
            };

            // act
            var result = await controller.UpdateCountry("TS3", request);

            // assert
            var value = ActionResultValidator.ValidateOkResultValue<CountryResponse>(result);
            Assert.AreEqual("Test3", value.Name);
            Assert.AreEqual("TS3", value.Id);
        }

        [TestMethod]
        public async Task DeleteCountry_WithValidId()
        {
            // arrange
            var country = new CountryEntity
            {
                Name = "Test4",
                OfficialName = "Test 4",
                Alpha2Code = "T4",
                Alpha3Code = "TS4",
                NumericCode = "045",
            };
            var mockRepo = new Mock<IRepository<CountryEntity>>();
            mockRepo.Setup(p => p.DeleteItemAsync(It.IsAny<string>())).ReturnsAsync(country);

            var controller = new CountriesController(mockRepo.Object);

            // act
            var result = await controller.DeleteCountry("TS4");

            // assert
            var value = ActionResultValidator.ValidateOkResultValue<CountryResponse>(result);
            Assert.AreEqual("Test4", value.Name);
            Assert.AreEqual("TS4", value.Id);
        }
    }
}
