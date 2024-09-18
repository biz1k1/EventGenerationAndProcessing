using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Processor.Infrastructure;
using Processor.Infrastructure.Repositories;
using Processor.Model.Interfaces;

namespace Processor.Services
{
    /// <summary>
    /// Класс для внедрения сервисов проекта
    /// </summary>
    public static class InjectionServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Подключение к бд
            services.AddDbContext<DataContext>(options => options.UseNpgsql(configuration.GetConnectionString("Pgsql")));

            //Логгер
			services.AddLogging(builder => builder.AddConsole());

            //Репозиторий
            services.AddScoped<IIncidentService, IncidentService>();
			services.AddHttpContextAccessor();

			return services;
        }
    }
}
