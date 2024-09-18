using Generator.Model.Entity;
using Processor.Model.DTO;
using Processor.Model.Entity;

namespace Processor.Model.Interfaces
{
	/// <summary>
	/// Интерфейс репозиторий инцидентов
	/// </summary>
	public interface IIncidentService
	{
		/// <summary>
		/// Метод для получения всех инцидентов
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<IncidentEntity>> GetAllIncidents();

		/// <summary>
		/// Метод добавляет инцидент вместе с событием
		/// </summary>
		/// <param name="eventDTO"></param>
		/// <returns></returns>
		Task AddIncidentWithEvent(EventDTO eventDTO);
	}
}
