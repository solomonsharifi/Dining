using Dining.Domain.Common.Models;

namespace Dining.Domain.Menus.Events;

public record MenuCreated(Menu Menu) : IDomainEvent;