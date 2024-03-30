using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebLista.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace WebLista.CrossCutting.Dependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServer");
        serviceCollection.AddDbContext<WebListaDbContext>(opt => opt.UseSqlServer(connectionString));

        return serviceCollection;
    }
}