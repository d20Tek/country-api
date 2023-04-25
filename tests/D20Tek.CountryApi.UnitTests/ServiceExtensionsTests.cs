//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.CountryApi.Entities;
using D20Tek.CountryApi.Repositories;
using D20Tek.Services.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace D20Tek.CountryApi.UnitTests
{
    [TestClass]
    public class ServiceExtensionsTests
    {
        [TestMethod]
        public void ConfigureCors()
        {
            // arrange
            var services = new ServiceCollection();

            // act
            services.AddSingleton<ILoggerFactory>(new Mock<ILoggerFactory>().Object);
            services.ConfigureCors();

            // assert
            Assert.AreEqual(9, services.Count);
            Assert.IsTrue(services.Any(p => p.ServiceType == typeof(ICorsService)));

            // act
            var provider = services.BuildServiceProvider();
            Assert.IsNotNull(provider.GetService<ICorsService>());
        }

        [TestMethod]
        public void ConfigureIISIntegration()
        {
            // arrange
            var services = new ServiceCollection();

            // act
            services.ConfigureIISIntegration();

            // assert
            Assert.AreEqual(6, services.Count);
            Assert.IsTrue(services.Any(p => p.ServiceType == typeof(IConfigureOptions<IISOptions>)));

            // act
            var provider = services.BuildServiceProvider();
            Assert.IsNotNull(provider.GetService<IConfigureOptions<IISOptions>>());
        }

        [TestMethod]
        public void AddRepositories()
        {
            // arrange
            var services = new ServiceCollection();

            // act
            services.AddRepositories();

            // assert
            Assert.AreEqual(1, services.Count);
            Assert.IsTrue(services.Any(p => p.ServiceType == typeof(IRepository<CountryEntity>)));
        }
    }
}
