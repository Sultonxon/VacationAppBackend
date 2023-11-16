using Microsoft.Extensions.DependencyInjection;
using VacationApp.Common.Repositories;
using VacationApp.Data.Repositories;

namespace VacationApp.Data;

public static class Extensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IVacationRepository, VacationRepository>();
        services.AddScoped<IVacationStatusRepository, VacationStatusRepository>();
    }
}