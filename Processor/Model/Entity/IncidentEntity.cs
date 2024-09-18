using Generator.Model.Entity;
using Processor.Model.Enum;

namespace Processor.Model.Entity
{
	/// <summary>
	/// Сущность для создания инцидента
	/// </summary>
	public class IncidentEntity
	{
		/// <summary>
		/// Id инцидента
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Перечисление типов инцидентов
		/// </summary>
		public int IncidentType { get; set; }

		/// <summary>
		/// Дата создания инцидента
		/// </summary>
		public DateTime Time { get; set; }

		/// <summary>
		/// Список событий инцидента
		/// </summary>
		public List<EventEntity> Events { get; set; } = [];
	}
}
