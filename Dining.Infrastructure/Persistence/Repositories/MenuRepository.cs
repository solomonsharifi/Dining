using Dining.Application.Common.Interfaces.Persistance;
using Dining.Domain.Menus;

namespace Dining.Infrastructure.Persistence.Repositories;

public sealed class MenuRepository : IMenuRepository
{
    private readonly DiningDbContext _dbContext;

    public MenuRepository(DiningDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }
}