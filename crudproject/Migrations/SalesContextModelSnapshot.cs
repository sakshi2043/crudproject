﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using crudproject.Models;

#nullable disable

namespace crudproject.Migrations
{
    [DbContext(typeof(SalesContext))]
    partial class SalesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("crudproject.Models.Customer", b =>
                {
                    b.Property<int>("CustId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("crudproject.Models.Product", b =>
                {
                    b.Property<int>("Productid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Productid"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.HasKey("Productid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("crudproject.Models.Sales", b =>
                {
                    b.Property<int>("Salesid")
                        .HasColumnType("int")
                        .HasColumnName("Salesid");

                    b.Property<int?>("Custid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Datesold")
                        .HasColumnType("datetime");

                    b.Property<int?>("Productid")
                        .HasColumnType("int");

                    b.Property<int?>("Storeid")
                        .HasColumnType("int")
                        .HasColumnName("Storeid");

                    b.HasKey("Salesid");

                    b.HasIndex("Custid");

                    b.HasIndex("Productid");

                    b.HasIndex("Storeid");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("crudproject.Models.Store", b =>
                {
                    b.Property<int>("Storeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Storeid"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Storeid");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("crudproject.Models.Sales", b =>
                {
                    b.HasOne("crudproject.Models.Customer", "Cust")
                        .WithMany("Sales")
                        .HasForeignKey("Custid");

                    b.HasOne("crudproject.Models.Product", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("Productid");

                    b.HasOne("crudproject.Models.Store", "Store")
                        .WithMany("Sales")
                        .HasForeignKey("Storeid");

                    b.Navigation("Cust");

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("crudproject.Models.Customer", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("crudproject.Models.Product", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("crudproject.Models.Store", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
