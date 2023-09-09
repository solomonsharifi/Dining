using Dining.Domain.Bills.ValueObjects;
using Dining.Domain.Common.Models;
using Dining.Domain.Dinners.ValueObjects;
using Dining.Domain.Guests.ValueObjects;
using Dining.Domain.Hosts.ValueObjects;

namespace Dining.Domain.Bills;

public sealed class Bill : AggregateRoot<BillId, Guid>
{
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public Price Price { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Bill(
        BillId id,
        GuestId guestId,
        HostId hostId,
        Price price,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(
        GuestId guestId,
        HostId hostId,
        Price price)
    {
        return new(
            BillId.CreateUnique(),
            guestId,
            hostId,
            price,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

#pragma warning disable CS8618
    private Bill() { }
#pragma warning restore CS8618
}