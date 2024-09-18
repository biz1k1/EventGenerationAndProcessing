using Generator.Services.BackgroundServices;

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

			services.AddLogging(builder => builder.AddConsole());
			return services;
		}
	}
}
