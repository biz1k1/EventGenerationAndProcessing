using Generator.Model.Interfaces;
using Generator.Services.BackgroundServices;
using Generator.Services.HttpServices;

namespace Generator.Services
{
    /// <summary>
    /// Класс для внедрения сервисов проект
    /// </summary>
    public static class InjectionServices
	{
		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddHostedService<HttpGeneratorService>();

			services.AddHttpClient();
			services.AddSingleton<IHttpPostingEvent, HttpPostingEvent>();
			services.AddLogging(builder => builder.AddConsole());
			return services;
		}
	}
}
