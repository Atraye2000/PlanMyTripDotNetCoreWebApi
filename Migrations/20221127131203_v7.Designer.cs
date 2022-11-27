﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using my_appApi.context;

#nullable disable

namespace my_appApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221127131203_v7")]
    partial class v7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("my_appApi.models.Admin", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("placeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("admins", (string)null);
                });

            modelBuilder.Entity("my_appApi.models.booking", b =>
                {
                    b.Property<int>("bookingid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookingid"), 1L, 1);

                    b.Property<int>("adults")
                        .HasColumnType("int");

                    b.Property<string>("checkInDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("children")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bookingid");

                    b.ToTable("bookingForm", (string)null);
                });

            modelBuilder.Entity("my_appApi.models.Flight", b =>
                {
                    b.Property<int>("fid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("fid"), 1L, 1);

                    b.Property<int?>("FlightBookingbid")
                        .HasColumnType("int");

                    b.Property<string>("arrivalTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("departureTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("seatAvl")
                        .HasColumnType("int");

                    b.Property<string>("source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("fid");

                    b.HasIndex("FlightBookingbid");

                    b.ToTable("flights", (string)null);
                });

            modelBuilder.Entity("my_appApi.models.FlightBooking", b =>
                {
                    b.Property<int>("bid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bid"), 1L, 1);

                    b.Property<string>("currentDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("fid")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasKey("bid");

                    b.ToTable("flightsBooking", (string)null);
                });

            modelBuilder.Entity("my_appApi.models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("my_appApi.models.Flight", b =>
                {
                    b.HasOne("my_appApi.models.FlightBooking", null)
                        .WithMany("Flights")
                        .HasForeignKey("FlightBookingbid");
                });

            modelBuilder.Entity("my_appApi.models.FlightBooking", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
