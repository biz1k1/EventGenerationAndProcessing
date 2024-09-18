namespace Processor.Model.DTO
{
	/// <summary>
	/// DTO для события
	/// </summary>
    public class EventDTO
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
	}
}
