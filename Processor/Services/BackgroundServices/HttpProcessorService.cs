
using Processor.Infrastructure;
using Processor.Model.Entity;
using Processor.Model.Intrefaces;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;

namespace Processor.Services.BackgroundServices
{
	public class HttpProcessorService : BackgroundService
	{
		private readonly IMyDbContextFactory _dbContextFactory;
		private readonly ILogger<HttpProcessorService> _logger;
		public HttpProcessorService(
			ILogger<HttpProcessorService> logger,
			IMyDbContextFactory dbContextFactory
			)
        {
			_dbContextFactory = dbContextFactory;
			_logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var httpListener = new HttpListener();
			httpListener.Prefixes.Add("https://localhost:7182/");
			try
			{
                httpListener.Start();
				var context = await httpListener.GetContextAsync();
				while (!stoppingToken.IsCancellationRequested)
				{
					Console.WriteLine("ping");
					var incident = await ConvertHttpRequest(stoppingToken, context);

					if(incident is not null)
					{
						using (var scope = _dbContextFactory.Create())
						{
							var dbContext = scope.Incident.Add(incident);
						}
					}
					await Task.Delay(1000);
				}
				httpListener.Close();

			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
            }
		}

		private async Task<IncidentEntity> ConvertHttpRequest(CancellationToken cancellationToken, HttpListenerContext httpListenerContext)
		{
			using var reader = new StreamReader(httpListenerContext.Request.InputStream, httpListenerContext.Request.ContentEncoding);

			var body = await reader.ReadToEndAsync();

			return JsonSerializer.Deserialize<IncidentEntity>(body);

		}
	}
}
