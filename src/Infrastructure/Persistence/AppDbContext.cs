using Ckn.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ckn.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    
     public DbSet<User> Users { get; set; }
}
