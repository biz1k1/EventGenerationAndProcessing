using Generator.Model.Entity;
using Generator.Model.Enum;
using Generator.Services.BackgroundServices;
using System.Text.Json;
using System.Text;
using Generator.Model.Interfaces;

namespace Generator.Services.HttpServices
{
    /// <summary>
    /// Класс для отправки событий через http запрос
    /// </summary>
    public class HttpPostingEvent : IHttpPostingEvent
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<HttpGeneratorService> _logger;

        public HttpPostingEvent(IHttpClientFactory httpClient, ILogger<HttpGeneratorService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<bool> PostEventAsync(EventTypeEnum eventType)
        {

            var httpClient = _httpClient.CreateClient();


            using StringContent jsonContent = new(
                JsonSerializer.Serialize(new EventEntity
                {
                    EventType = eventType,
                    Time = DateTime.UtcNow
                }),
            Encoding.UTF8,
            "application/json");

            var response = await httpClient.PostAsync("https://localhost:7270/PostIncident/", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                _logger.LogError("Запрос не был передан" + response.Content);
                return false;
            }

        }
    }
}
