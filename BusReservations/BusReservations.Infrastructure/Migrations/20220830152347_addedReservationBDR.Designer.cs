﻿// <auto-generated />
using System;
using BusReservations.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusReservations.Infrastructure.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220830152347_addedReservationBDR")]
    partial class addedReservationBDR
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.7.22376.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusReservations.Core.Domain.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HasAdminPrivileges")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BusReservations.Core.Domain.Bus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("BusReservations.Core.Domain.BusDrivenRoute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DrivenRouteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.HasIndex("DrivenRouteId");

                    b.ToTable("BusDrivenRoutes");
                });

            modelBuilder.Entity("BusReservations.Core.Domain.DrivenRoute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SeatPrice")
                        .HasColumnType("real");

                    b.Property<string>("Start")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TimeTableId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TimeTableId");

                    b.ToTable("DrivenRoutes");
                });

            modelBuilder.Entity("BusReservations.Core.Domain.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusDrivenRouteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DrivenRouteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("FinalSeatPrice")
                        .HasColumnType("real");

                    b.Property<Guid>("SeatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BusDrivenRouteId");

                    b.HasIndex("SeatId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("BusReservations.Core.Domain.SeatModel.Seat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<Guid?>("DrivenRouteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DrivenRouteId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("BusReservations.Core.Domain.TimeTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ArivvalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("TimeTables");
                });

            modelBuilder.Entity("BusReservations.Core.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BusReservations.Core.Domain.Account", b =>
                {
                    b.HasOne("BusReservations.Core.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BusReservations.Core.Domain.BusDrivenRoute", b =>
                {
                    b.HasOne("BusReservations.Core.Domain.Bus", "Bus")
                        .WithMany("BusDrivenRoutes")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusReservations.Core.Domain.DrivenRoute", "DrivenRoute")
                        .WithMany("BusDrivenRoutes")
                        .HasForeignKey("DrivenRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("DrivenRoute");
                });

            modelBuilder.Entity("BusReservations.Core.Domain.DrivenRoute", b =>
                {
                    b.HasOne("BusReservations.Core.Domain.TimeTable", "TimeTable")
                        .WithMany()
                        .HasForeignKey("TimeTableId");

                    b.Navigation("TimeTable");
                });

            modelBuilder.Entity("BusReservations.Core.Domain.Reservation", b =>
                {
                    b.HasOne("BusReservations.Core.Domain.BusDrivenRoute", "BusDrivenRoute")
                        .WithMany()
                        .HasForeignKey("BusDrivenRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusReservations.Core.Domain.SeatModel.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusReservations.Core.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusDrivenRoute");

                    b.Navigation("Seat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BusReservations.Core.Domain.SeatModel.Seat", b =>
                {
                    b.HasOne("BusReservations.Core.Domain.DrivenRoute", null)
                        .WithMany("OccupiedSeats")
                        .HasForeignKey("DrivenRouteId");
                });

            modelBuilder.Entity("BusReservations.Core.Domain.Bus", b =>
                {
                    b.Navigation("BusDrivenRoutes");
                });

            modelBuilder.Entity("BusReservations.Core.Domain.DrivenRoute", b =>
                {
                    b.Navigation("BusDrivenRoutes");

                    b.Navigation("OccupiedSeats");
                });
#pragma warning restore 612, 618
        }
    }
}
