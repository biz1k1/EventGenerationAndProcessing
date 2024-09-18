
using Processor.Model.Entity;

namespace Generator.Model.Entity
{
	/// <summary>
	/// Сущность для созданий событий
	/// </summary>
	public class EventEntity
	{
		/// <summary>
		/// Id события
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Перечисление типов событий
		/// </summary>
		public int EventType { get; set; }

		/// <summary>
		/// Дата генерации события
		/// </summary>
		public DateTime Time { get; set; }

		/// <summary>
		/// Индицент события
		/// </summary>
		public List<IncidentEntity> Incident { get; set; } = [];
	}
}
