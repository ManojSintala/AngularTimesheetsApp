﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeSheet.API.Data;

namespace timesheet.api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("TimeSheet.API.Data.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<DateTime?>("Deadline");

                    b.Property<bool>("IsFinished");

                    b.Property<string>("ProjectName");

                    b.Property<DateTime?>("ProjectStart");

                    b.Property<float>("SpentHours");

                    b.Property<int?>("UserId");

                    b.HasKey("ProjectId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TimeSheet.API.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("Gender");

                    b.Property<DateTime>("LastActive");

                    b.Property<string>("Name");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Surname");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TimeSheet.API.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.Property<string>("KodPocztowy");

                    b.Property<string>("Miasto");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("PrzedstawicielImie");

                    b.Property<string>("PrzedstawicielNazwisko");

                    b.Property<string>("Ulica");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TimeSheet.API.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HeadOfProjectId");

                    b.Property<float>("SpentHours");

                    b.Property<DateTime?>("TimeEnd");

                    b.Property<DateTime>("TimeStart");

                    b.HasKey("GroupId");

                    b.HasIndex("HeadOfProjectId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("TimeSheet.API.Models.Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GroupId");

                    b.Property<string>("Role");

                    b.Property<DateTime>("TimeAdded");

                    b.Property<float>("TimeSpent");

                    b.Property<int>("UserId");

                    b.HasKey("WorkerId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("TimeSheet.API.Data.Project", b =>
                {
                    b.HasOne("TimeSheet.API.Models.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TimeSheet.API.Data.User")
                        .WithMany("Groups")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TimeSheet.API.Models.Group", b =>
                {
                    b.HasOne("TimeSheet.API.Models.Worker", "HeadOfProject")
                        .WithMany()
                        .HasForeignKey("HeadOfProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TimeSheet.API.Models.Worker", b =>
                {
                    b.HasOne("TimeSheet.API.Models.Group")
                        .WithMany("Members")
                        .HasForeignKey("GroupId");

                    b.HasOne("TimeSheet.API.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
