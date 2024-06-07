using Mapster;
using PersonalAccounts2._0.DataAccess.Models;
using PersonalAccounts2._0.DTO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace PersonalAccounts.MappingConfigurations
{
    public static class AccountMappingConfiguration
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<List<AccountModel>, List<AccountWithResidentsDTO>>
                .NewConfig()
                .Map(dest => dest, src => src.Select(a => a.Adapt<AccountWithResidentsDTO>()));


            TypeAdapterConfig<AccountModel, AccountWithResidentsDTO>
            .NewConfig()
            .Map(dest => dest.Residents, src => src.AccountResidents.Select(r => r.Resident));

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
