using System;
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

        public virtual DbSet<Accommodation> Accommodation { get; set; }
        public virtual DbSet<AccommodationCategory> AccommodationCategory { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<ListServices> ListServices { get; set; }
        public virtual DbSet<Meals> Meals { get; set; }
        public virtual DbSet<Role> Role { get; set; }
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
            modelBuilder.Entity<Accommodation>(entity =>
            {
                entity.Property(e => e.AccName).HasMaxLength(50);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.AccCategoryNavigation)
                    .WithMany(p => p.Accommodation)
                    .HasForeignKey(d => d.AccCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accommodation_AccommodationCategory");
            });

            modelBuilder.Entity<AccommodationCategory>(entity =>
            {
                entity.Property(e => e.Charge).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

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
                    .HasForeignKey(d => d.CusId)
                    .HasConstraintName("FK_Bill_Customer1");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AccId, e.CusId })
                    .HasName("PK_Booking_1");

                entity.Property(e => e.AccId).HasColumnName("AccID");

                entity.Property(e => e.CusId).HasColumnName("CusID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.InDate).HasColumnType("datetime");

                entity.Property(e => e.Luggage).HasColumnType("text");

                entity.Property(e => e.OutDate).HasColumnType("datetime");

                entity.HasOne(d => d.Acc)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.AccId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Accommodation");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.CusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Customer1");
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
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_Employee_Role");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.IdAccount)
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

            modelBuilder.Entity<ServiceOfAcc>(entity =>
            {
                entity.HasKey(e => new { e.IdAccount, e.IdServices });

                entity.Property(e => e.DateStart).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.ServiceOfAcc)
                    .HasForeignKey(d => d.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceOfAcc_Account");

                entity.HasOne(d => d.IdServicesNavigation)
                    .WithMany(p => p.ServiceOfAcc)
                    .HasForeignKey(d => d.IdServices)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceOfAcc_ListServices");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AccId, e.MealId })
                    .HasName("PK_Services_1");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AccId).HasColumnName("AccID");

                entity.Property(e => e.MealId).HasColumnName("MealID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.HasOne(d => d.Acc)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.AccId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_Accommodation1");

                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.MealId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_Meals");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
