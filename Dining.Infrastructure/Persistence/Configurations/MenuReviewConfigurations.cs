using Dining.Domain.Dinners.ValueObjects;
using Dining.Domain.Guests.ValueObjects;
using Dining.Domain.Hosts.ValueObjects;
using Dining.Domain.MenuReview;
using Dining.Domain.MenuReview.ValueObjects;
using Dining.Domain.Menus.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dining.Infrastructure.Persistence.Configurations;

public sealed class MenuReviewConfigurations : IEntityTypeConfiguration<MenuReview>
{
    public void Configure(EntityTypeBuilder<MenuReview> builder)
    {
        ConfigureMenuReviewsTable(builder);
    }

    private void ConfigureMenuReviewsTable(EntityTypeBuilder<MenuReview> builder)
    {
        builder
            .ToTable("MenuReviews");

        builder
            .HasKey(mr => mr.Id);

        builder
            .Property(mr => mr.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuReviewId.Create(value));

        builder
            .OwnsOne(mr => mr.Rating);

        builder
            .Property(mr => mr.Comment)
            .HasMaxLength(1000);

        builder
            .Property(mr => mr.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder
            .Property(mr => mr.MenuId)
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder
            .Property(mr => mr.GuestId)
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));

        builder
            .Property(mr => mr.DinnerId)
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));
    }
}