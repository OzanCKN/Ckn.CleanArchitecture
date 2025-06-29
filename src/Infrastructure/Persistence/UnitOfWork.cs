using Ckn.Application.Common;
using Ckn.Domain.Common;

namespace Ckn.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    private readonly DomainEventDispatcher _dispatcher;

    public UnitOfWork(AppDbContext dbContext, DomainEventDispatcher dispatcher)
    {
        _dbContext = dbContext;
        _dispatcher = dispatcher;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //Tüm aggregate rootları bul
        var aggregates = _dbContext.ChangeTracker.Entries<AggregateRoot<Guid>>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity)
            .ToList();

        var domainEvents = aggregates.SelectMany(a => a.DomainEvents).ToList();

        var result = await _dbContext.SaveChangesAsync(cancellationToken);

        await _dispatcher.DispatchAsync(domainEvents, cancellationToken);
        aggregates.ForEach(a => a.ClearDomainEvents());

        return result;
    }
}
