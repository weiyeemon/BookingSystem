﻿// <auto-generated />
using System;
using Booking.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Booking.Model.Migrations
{
    [DbContext(typeof(BookingDBContext))]
    partial class BookingDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Booking.Model.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Country")
                        .HasColumnType("int");

                    b.Property<int>("Credit")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Packages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = 1,
                            Credit = 3,
                            EndTime = new DateTime(2023, 11, 18, 17, 19, 0, 441, DateTimeKind.Local).AddTicks(6329),
                            Name = "Basic",
                            StartTime = new DateTime(2023, 11, 11, 17, 19, 0, 441, DateTimeKind.Local).AddTicks(6310)
                        },
                        new
                        {
                            Id = 2,
                            Country = 3,
                            Credit = 2,
                            EndTime = new DateTime(2023, 11, 18, 17, 19, 0, 441, DateTimeKind.Local).AddTicks(6346),
                            Name = "Intermidiate",
                            StartTime = new DateTime(2023, 11, 11, 17, 19, 0, 441, DateTimeKind.Local).AddTicks(6344)
                        },
                        new
                        {
                            Id = 3,
                            Country = 0,
                            Credit = 3,
                            EndTime = new DateTime(2023, 11, 18, 17, 19, 0, 441, DateTimeKind.Local).AddTicks(6351),
                            Name = "Basic",
                            StartTime = new DateTime(2023, 11, 11, 17, 19, 0, 441, DateTimeKind.Local).AddTicks(6349)
                        });
                });

            modelBuilder.Entity("Booking.Model.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.HasIndex("UserId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Booking.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TotalCredit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PackageUser", b =>
                {
                    b.Property<int>("PackagesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("PackagesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("PackageUser");
                });

            modelBuilder.Entity("Booking.Model.Schedule", b =>
                {
                    b.HasOne("Booking.Model.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PackageUser", b =>
                {
                    b.HasOne("Booking.Model.Package", null)
                        .WithMany()
                        .HasForeignKey("PackagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}