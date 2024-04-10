using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Core.Application.Interfaces;
using TestTask.Infrastructure.Persistence.Implementations;
using TestTask.Infrastructure.Persistence.Implementations.Repository;

namespace TestTask.Infrastructure.Persistence
{
    public static class ServiceExtention
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration.GetConnectionString("DefaultConnection"));
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));         
            services.AddScoped<IUnitOfWork, UnitOfWork>();      

            return services;
        }
      
    }
}
