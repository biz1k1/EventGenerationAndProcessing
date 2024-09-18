using Generator.Model.Entity;
using Generator.Model.Enum;

namespace Generator.Model.Interfaces
{
	/// <summary>
	/// Интерфейс для автоматических и постоянных сервисов
	/// </summary>
	public interface IHttpPostingEvent
	{
		Task<bool> PostEventAsync(EventTypeEnum eventType);
	}
}
