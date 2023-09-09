using Dining.Domain.Bills;
using Dining.Domain.Common.Models;
using Dining.Domain.Dinners;
using Dining.Domain.Guests;
using Dining.Domain.Hosts;
using Dining.Domain.MenuReview;
using Dining.Domain.Menus;
using Dining.Domain.Users;
using Dining.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Dining.Infrastructure.Persistence;

public sealed class DiningDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public DiningDbContext(
        DbContextOptions<DiningDbContext> options,
        PublishDomainEventsInterceptor publishDomainEventsInterceptor
    ) : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public DbSet<Bill> Bills { get; set; } = null!;
    public DbSet<Dinner> Dinners { get; set; } = null!;
    public DbSet<Guest> Guests { get; set; } = null!;
    public DbSet<Host> Hosts { get; set; } = null!;
    public DbSet<Menu> Menus { get; set; } = null!;
    public DbSet<MenuReview> MenuReviews { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(DiningDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .AddInterceptors(_publishDomainEventsInterceptor);

        base.OnConfiguring(optionsBuilder);
    }
}