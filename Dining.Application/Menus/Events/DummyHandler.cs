using Dining.Domain.Menus.Events;
using MediatR;

namespace Dining.Application.Menus.Events;

public class DummyHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(
        MenuCreated notification,
        CancellationToken cancellationToken
    )
    {
        return Task.CompletedTask;
    }
}