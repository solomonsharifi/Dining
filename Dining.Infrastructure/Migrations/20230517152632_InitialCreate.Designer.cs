﻿// <auto-generated />
using System;
using Dining.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dining.Infrastructure.Migrations
{
    [DbContext(typeof(DiningDbContext))]
    [Migration("20230517152632_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dining.Domain.Bills.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Bills", (string)null);
                });

            modelBuilder.Entity("Dining.Domain.Dinners.Dinner", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<int>("MaxGuests")
                        .HasColumnType("int");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Dinners", (string)null);
                });

            modelBuilder.Entity("Dining.Domain.Guests.Guest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Guests", (string)null);
                });

            modelBuilder.Entity("Dining.Domain.Hosts.Host", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Hosts", (string)null);
                });

            modelBuilder.Entity("Dining.Domain.MenuReview.MenuReview", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("DinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("MenuReviews", (string)null);
                });

            modelBuilder.Entity("Dining.Domain.Menus.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("Dining.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Dining.Domain.Bills.Bill", b =>
                {
                    b.OwnsOne("Dining.Domain.Bills.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("BillId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BillId");

                            b1.ToTable("Bills");

                            b1.WithOwner()
                                .HasForeignKey("BillId");
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("Dining.Domain.Dinners.Dinner", b =>
                {
                    b.OwnsOne("Dining.Domain.Bills.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("DinnerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DinnerId");

                            b1.ToTable("Dinners");

                            b1.WithOwner()
                                .HasForeignKey("DinnerId");
                        });

                    b.OwnsMany("Dining.Domain.Dinners.Entities.Reservation", "Reservations", b1 =>
                        {
                            b1.Property<Guid>("DinnerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("ArrivalDateTime")
                                .HasColumnType("datetime2");

                            b1.Property<Guid>("BillId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("GuestCount")
                                .HasColumnType("int");

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("ReservationStatus")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DinnerId", "Id");

                            b1.ToTable("Reservations", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("DinnerId");
                        });

                    b.OwnsOne("Dining.Domain.Dinners.ValueObjects.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("DinnerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DinnerId");

                            b1.ToTable("Dinners");

                            b1.WithOwner()
                                .HasForeignKey("DinnerId");
                        });

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Dining.Domain.Hosts.Host", b =>
                {
                    b.OwnsOne("Dining.Domain.Common.ValueObjects.AverageRating", "AverageRating", b1 =>
                        {
                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("NumRatings")
                                .HasColumnType("int");

                            b1.Property<double>("Value")
                                .HasColumnType("float");

                            b1.HasKey("HostId");

                            b1.ToTable("Hosts");

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.OwnsMany("Dining.Domain.Dinners.ValueObjects.DinnerId", "DinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("HostDinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("HostId");

                            b1.ToTable("HostDinnerIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.OwnsMany("Dining.Domain.Menus.ValueObjects.MenuId", "MenuIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("HostMenuId");

                            b1.HasKey("Id");

                            b1.HasIndex("HostId");

                            b1.ToTable("HostMenuIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.Navigation("AverageRating")
                        .IsRequired();

                    b.Navigation("DinnerIds");

                    b.Navigation("MenuIds");
                });

            modelBuilder.Entity("Dining.Domain.MenuReview.MenuReview", b =>
                {
                    b.OwnsOne("Dining.Domain.Common.ValueObjects.Rating", "Rating", b1 =>
                        {
                            b1.Property<Guid>("MenuReviewId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Value")
                                .HasColumnType("float");

                            b1.HasKey("MenuReviewId");

                            b1.ToTable("MenuReviews");

                            b1.WithOwner()
                                .HasForeignKey("MenuReviewId");
                        });

                    b.Navigation("Rating")
                        .IsRequired();
                });

            modelBuilder.Entity("Dining.Domain.Menus.Menu", b =>
                {
                    b.OwnsMany("Dining.Domain.MenuReview.ValueObjects.MenuReviewId", "MenuReviewIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ReviewId");

                            b1.HasKey("Id");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuReviewIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.OwnsMany("Dining.Domain.Menus.Entites.MenuSection", "Sections", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("MenuSectionId");

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("Id", "MenuId");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuSections", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");

                            b1.OwnsMany("Dining.Domain.Menus.Entites.MenuItem", "Items", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("uniqueidentifier")
                                        .HasColumnName("MenuItemId");

                                    b2.Property<Guid>("MenuSectionId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("MenuId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.HasKey("Id", "MenuSectionId", "MenuId");

                                    b2.HasIndex("MenuSectionId", "MenuId");

                                    b2.ToTable("MenuItems", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("MenuSectionId", "MenuId");
                                });

                            b1.Navigation("Items");
                        });

                    b.OwnsOne("Dining.Domain.Common.ValueObjects.AverageRating", "AverageRating", b1 =>
                        {
                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("NumRatings")
                                .HasColumnType("int");

                            b1.Property<double>("Value")
                                .HasColumnType("float");

                            b1.HasKey("MenuId");

                            b1.ToTable("Menus");

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.OwnsMany("Dining.Domain.Dinners.ValueObjects.DinnerId", "DinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("DinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuDinnerIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.Navigation("AverageRating")
                        .IsRequired();

                    b.Navigation("DinnerIds");

                    b.Navigation("MenuReviewIds");

                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
