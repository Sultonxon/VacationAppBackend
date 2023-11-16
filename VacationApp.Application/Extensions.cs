using Microsoft.Extensions.DependencyInjection;
using VacationApp.Application.Services;
using VacationApp.Common.Services;

namespace VacationApp.Application;

public static class Extensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IVacationService, VacationService>();
        services.AddScoped<IAuthService, AuthService>();
    }
}