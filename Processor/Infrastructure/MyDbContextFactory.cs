using Microsoft.Extensions.DependencyInjection;
using Processor.Model.Intrefaces;

namespace Processor.Infrastructure
{
	public class MyDbContextFactory : IMyDbContextFactory
	{
		private readonly IServiceScope? _scope;
		public MyDbContextFactory(IServiceScopeFactory serviceScopeFactory)
        {
			_scope = serviceScopeFactory.CreateScope();
		}
        public DataContext Create()
		{
			if (_scope == null)
			{
				throw new NullReferenceException("Failed creating scope");

			}

			return _scope.ServiceProvider.GetRequiredService<DataContext>();
		}
	}
}
