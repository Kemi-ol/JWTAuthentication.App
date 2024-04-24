﻿// <auto-generated />
using System;
using Authentication.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Authentication.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240423134729_jwt_authorisation")]
    partial class jwt_authorisation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Authentication.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("EmployeeID");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginID")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("MaritalStatus")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("NationalIDNumber")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("RowGuid")
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<short>("SickLeaveHours")
                        .HasColumnType("INTEGER");

                    b.Property<short>("VacationHours")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("Authentication.Model.UserInfo", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("UserInfo", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}