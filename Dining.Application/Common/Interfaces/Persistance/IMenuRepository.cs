using Dining.Domain.Menus;

namespace Dining.Application.Common.Interfaces.Persistance;

public interface IMenuRepository
{
    void Add(Menu menu);
}