using Application.CQRS.Commands;
using Application.CQRS.Queries;

namespace Application.CQRS.Handlers
{
    public class GenericHandler
    {
        private readonly IServiceProvider _serviceProvider;

        public GenericHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Handle<THandler>(ICommand command)
        {
            dynamic handler = _serviceProvider.GetService(typeof(THandler));

            handler.Handle((dynamic)command);
        }

        public TResponse Handle<THandler, TResponse>(IQuery query)
        {
            dynamic handler = _serviceProvider.GetService(typeof(THandler));

            return handler.Handle((dynamic)query);
        }
    }
}
