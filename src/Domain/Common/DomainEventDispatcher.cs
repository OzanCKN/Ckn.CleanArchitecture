namespace Ckn.Domain.Common;
 
using Microsoft.Extensions.DependencyInjection;

public class DomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        foreach (var domainEvent in domainEvents)
        {
            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            var handlers = _serviceProvider.GetServices(handlerType);

            foreach (var handler in handlers)
            {
                var handleMethod = handlerType.GetMethod("Handle");
                if (handleMethod != null)
                {
                    var task = (Task)handleMethod.Invoke(handler, new object[] { domainEvent, cancellationToken })!;
                    await task;
                }
            }
        }
    }
}
