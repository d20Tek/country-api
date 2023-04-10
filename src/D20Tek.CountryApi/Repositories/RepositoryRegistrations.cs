//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Country.Shared.Models;
using D20Tek.CountryApi.Common;

namespace D20Tek.CountryApi.Repositories
{
    internal static class RepositoryRegistrations
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<CountryModel>, CountryRepository>();
            return services;
        }
    }
}
