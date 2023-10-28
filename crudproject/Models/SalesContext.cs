using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace crudproject.Models
{
    public class SalesContext : DbContext
    {

        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Sales> Sales { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sales>(entity =>
            {


                entity.Property(e => e.Salesid)
                  //  .ValueGeneratedNever()
                    .HasColumnName("Salesid");
                entity.Property(e => e.Datesold).HasColumnType("datetime");
                entity.Property(e => e.Storeid).HasColumnName("Storeid");

                entity.HasOne(d => d.Cust).WithMany(p => p.Sales)
                    .HasForeignKey(d => d.Custid);

                entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                    .HasForeignKey(d => d.Productid);

                entity.HasOne(d => d.Store).WithMany(p => p.Sales)
                    .HasForeignKey(d => d.Storeid);
            });

        }


        } }

