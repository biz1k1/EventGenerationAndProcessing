using Processor.Infrastructure;

namespace Processor.Model.Intrefaces
{
	public interface IMyDbContextFactory
	{
		DataContext Create();
	}
}
