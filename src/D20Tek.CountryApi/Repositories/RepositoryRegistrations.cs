//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.CountryApi.Entities;
using D20Tek.Services.Core;

namespace D20Tek.CountryApi.Repositories
{
    internal static class RepositoryRegistrations
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<CountryEntity>, CountryRepository>();
            return services;
        }
    }
}
