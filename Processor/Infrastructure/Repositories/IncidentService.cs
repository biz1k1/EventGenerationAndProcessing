using Generator.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Processor.Model.DTO;
using Processor.Model.Entity;
using Processor.Model.Interfaces;

namespace Processor.Infrastructure.Repositories
{
	/// <summary>
	/// Репозиторий инцидентов
	/// </summary>
	public class IncidentService: IIncidentService
	{
        private readonly DataContext _dataContext;
        public IncidentService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

		/// <summary>
		/// Добавление инцидента в бд 
		/// </summary>
		/// <param name="eventDTO"></param>
		/// <returns></returns>
		/// 

		// Сделал все в одну кучу, не хватило времени чтобы сделать распределение на репозиторий и сервисы
		public async Task AddIncidentWithEvent(EventDTO eventDTO)
		{
			var incidentEntity = new IncidentEntity
			{
				IncidentType = eventDTO.EventType,
				Time = DateTime.UtcNow,
			};
			var eventEntity = new EventEntity
			{
				EventType = eventDTO.EventType,
				Time = eventDTO.Time
			};

			_dataContext.Events.Add(eventEntity);
			await _dataContext.SaveChangesAsync();

			incidentEntity.Events.Add(eventEntity);

			_dataContext.Incident.Add(incidentEntity);
			await _dataContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<IncidentEntity>> GetAllIncidents()
		{
			return await _dataContext.Incident.Include(x => x.Events).ToListAsync(); 
		}
	}
}
