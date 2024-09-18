using Generator.Model.Enum;
using Microsoft.AspNetCore.Mvc;
using Generator.Model.Entity;
using Generator.Model.Interfaces;
namespace Generator.Controllers
{
	public class GeneratorController : Controller
	{
		private readonly IHttpPostingEvent _httpPostingEvent;
        public GeneratorController(IHttpPostingEvent httpPostingEvent)
        {
			_httpPostingEvent = httpPostingEvent;
        }

		/// <summary>
		/// Создает вручную события для отправки
		/// </summary>
		/// <param name="eventType">Тип события</param>
		/// <returns></returns>
        [Route(template: "GetIncident")]
		[HttpPost]
		public async Task<IActionResult> CreateEvent(EventTypeEnum eventType)
		{
			var completed=await _httpPostingEvent.PostEventAsync(eventType);

			if (!completed)
			{
				return BadRequest();
			}

			return Ok();
		}
	}
}
