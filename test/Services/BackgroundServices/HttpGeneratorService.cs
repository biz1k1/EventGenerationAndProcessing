using System.Text;
using System.Text.Json;
using Generator.Model.Entity;
using Generator.Model.Enum;
using Generator.Model.Interfaces;
namespace Generator.Services.BackgroundServices
{
	/// <summary>
	/// Класс для автоматических и постоянных сервисов
	/// </summary>
	public class HttpGeneratorService : BackgroundService
	{
		private readonly ILogger<HttpGeneratorService> _logger;
		private readonly TimeSpan _interval = TimeSpan.FromSeconds(30);
		private readonly IHttpPostingEvent _httpPostingEvent;
		public HttpGeneratorService(ILogger<HttpGeneratorService> logger, IHttpPostingEvent httpPostingEvent)
		{
			_logger = logger;
			_httpPostingEvent = httpPostingEvent;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{

			try
			{
				while (!stoppingToken.IsCancellationRequested)
				{

					await _httpPostingEvent.PostEventAsync(EventTypeEnum.FirstEvent);

					await Task.Delay(_interval, stoppingToken);
				}

			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}
		}
	}
}
