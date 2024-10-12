using Impar.Application.Services;
using Impar.Domain.Contracts.Repositories;
using Impar.Infra.EF;
using Impar.Infra.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Impar.IoC;
public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
            connectionString,
            b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName))
        );

        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<ICardService, CardService>();
        services.AddScoped<IPhotoRepository, PhotoRepository>();

        return services;
    }
}
