﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebHotel.Models.Entities
{
    public partial class HotelManagementContext : DbContext
    {
        public HotelManagementContext()
        {
        }

        public HotelManagementContext(DbContextOptions<HotelManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<ListServices> ListServices { get; set; }
        public virtual DbSet<Meals> Meals { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomCategory> RoomCategory { get; set; }
        public virtual DbSet<ServiceOfAcc> ServiceOfAcc { get; set; }
        public virtual DbSet<Services> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=HotelManagement;user id=sa;password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.CusId).HasColumnName("CusID");

                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(x => x.CusId)
                    .HasConstraintName("FK_Bill_Customer1");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(x => new { x.Id, x.RoomId, x.CusId })
                    .HasName("PK_Booking_1");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.CusId).HasColumnName("CusID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.InDate).HasColumnType("datetime");

                entity.Property(e => e.Luggage).HasColumnType("text");

                entity.Property(e => e.OutDate).HasColumnType("datetime");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(x => x.CusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Customer1");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(x => x.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Accommodation");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("decimal(8, 0)");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(x => x.IdRole)
                    .HasConstraintName("FK_Employee_Role");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(x => x.IdAccount)
                    .HasConstraintName("FK_Invoice_Account");
            });

            modelBuilder.Entity<ListServices>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Func).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Meals>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Charge).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoomName).HasMaxLength(50);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.RoomCategoryNavigation)
                    .WithMany(p => p.Room)
                    .HasForeignKey(x => x.RoomCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accommodation_AccommodationCategory");
            });

            modelBuilder.Entity<RoomCategory>(entity =>
            {
                entity.Property(e => e.Charge).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ServiceOfAcc>(entity =>
            {
                entity.HasKey(x => new { x.IdAccount, x.IdServices });

                entity.Property(e => e.DateStart).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.ServiceOfAcc)
                    .HasForeignKey(x => x.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceOfAcc_Account");

                entity.HasOne(d => d.IdServicesNavigation)
                    .WithMany(p => p.ServiceOfAcc)
                    .HasForeignKey(x => x.IdServices)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceOfAcc_ListServices");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(x => new { x.Id, x.RoomId, x.MealId })
                    .HasName("PK_Services_1");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.MealId).HasColumnName("MealID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.Services)
                    .HasForeignKey(x => x.MealId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_Meals");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Services)
                    .HasForeignKey(x => x.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_Accommodation1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
