using System.Text;
using System.Text.Json;
using Generator.Model.Entity;

namespace Generator.Services.BackgroundServices
{
	public class HttpGeneratorService : BackgroundService
	{
		private readonly IHttpClientFactory _httpClient;
		private readonly ILogger<HttpGeneratorService> _logger;
		private readonly TimeSpan _interval = TimeSpan.FromSeconds(5);
		public HttpGeneratorService(IHttpClientFactory httpClient,ILogger<HttpGeneratorService> logger)
		{
			_httpClient = httpClient;
			_logger = logger;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var httpClient = _httpClient.CreateClient();
			try
			{
				while (!stoppingToken.IsCancellationRequested)
				{
					await PostEventAsync(httpClient);

					await Task.Delay(_interval, stoppingToken);
				}

			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}
		}

		private async Task PostEventAsync(HttpClient httpClient)
		{
			using StringContent jsonContent = new(
				JsonSerializer.Serialize(new EventEntity
				{
					EventType= Model.Enum.EventTypeEnum.FirstEvent,
					Time=DateTime.Now
				}),
			Encoding.UTF8,
			"application/json");

			var response = await httpClient.PostAsync("https://localhost:7270", jsonContent);

			if (response.IsSuccessStatusCode)
			{
				_logger.LogDebug(response.StatusCode.ToString());
			}
			else
			{
				_logger.LogError("Запрос не был передан"+response.Content);
			}

		}
	}
}
