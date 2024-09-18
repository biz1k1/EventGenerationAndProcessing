using Processor.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Processor.Infrastructure;
using Processor.Model.Entity;
using Processor.Infrastructure.Repositories;
using Processor.Model.Interfaces;

namespace Processor.Controllers
{
	[ApiController]
	public class ProcessorController : ControllerBase
	{
		private readonly IIncidentService _incidentService;
		public ProcessorController(IIncidentService incidentService)
        {
			_incidentService = incidentService;

		}
		/// <summary>
		/// Метод получает все инциденты
		/// </summary>
		/// <returns></returns>
		[Route(template: "GetAllIncidents")]
		[HttpGet]
		public async Task<IActionResult> GetAllIncident()
		{
			var incidents = await _incidentService.GetAllIncidents();

			return Ok(incidents);
		}
		
		/// <summary>
		/// Метод создает инцидент на основе событий
		/// </summary>
		/// <param name="eventEntity">Получаемое событие</param>
		/// <returns></returns>
		[Route(template: "PostIncident")]
		[HttpPost]
		public async Task<IActionResult> PostIncident([FromBody] EventDTO eventDTO)
		{
			if (eventDTO == null)
			{
				return BadRequest("Invalid data.");
			}

			await _incidentService.AddIncidentWithEvent(eventDTO);

			return Ok();
		}
	}
}
