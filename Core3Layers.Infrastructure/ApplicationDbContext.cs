using System;
using Core3Layers.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core3Layers.Infrastructure
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerPhones> CustomerPhones { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_Company_1");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.Company)
                    .HasForeignKey<Company>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Customer");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PostalCode).HasMaxLength(10);
            });

            modelBuilder.Entity<CustomerPhones>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_CustomerPhones_1");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.CustomerPhones)
                    .HasForeignKey<CustomerPhones>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerPhones_Customer");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_Person_1");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11);

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.Person)
                    .HasForeignKey<Person>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Customer");
            });
        }
    }
}
