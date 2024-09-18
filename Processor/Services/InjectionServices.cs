using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Processor.Infrastructure;
using Processor.Model.Intrefaces;
using Processor.Services.BackgroundServices;

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

            services.AddHttpClient();
			// Сервис для получения ивентов
			services.AddHostedService<HttpProcessorService>();

			services.AddLogging(builder => builder.AddConsole());

			services.AddSingleton<IMyDbContextFactory, MyDbContextFactory>();
			return services;
        }
    }
}
