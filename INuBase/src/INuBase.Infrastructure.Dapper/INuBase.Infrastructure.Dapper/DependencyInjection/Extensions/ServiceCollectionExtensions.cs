using INuBase.Domain.Abstractions.Dappers;
using INuBase.Domain.Abstractions.Dappers.Repositories.Product;
using INuBase.Infrastructure.Dapper.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace INuBase.Infrastructure.Dapper.DependencyInjection.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureDapper(this IServiceCollection services)
        => services.AddTransient<IProductRepository, ProductRepository>()
            .AddTransient<IUnitOfWork, UnitOfWork>();
}
