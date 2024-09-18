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
		public IncidentTypeEnum IncidentType { get; set; }

		/// <summary>
		/// Дата создания инцидента
		/// </summary>
		public DateTime Time { get; set; }
	}
}
