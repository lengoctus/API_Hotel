using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web_HotelManagement.Models.Entities
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
        public virtual DbSet<Admission> Admission { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<ListServices> ListServices { get; set; }
        public virtual DbSet<Meals> Meals { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<ServicesOfAcc> ServicesOfAcc { get; set; }

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
                entity.HasKey(e => new { e.Id, e.AccCategory });

                entity.Property(e => e.AccName).HasMaxLength(50);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.AccCategoryNavigation)
                    .WithMany(p => p.Accommodation)
                    .HasForeignKey(d => d.AccCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accommodation_AccommodationCategory");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Accommodation)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accommodation_Admission");

                entity.HasOne(d => d.Id1)
                    .WithMany(p => p.Accommodation)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accommodation_Meals");
            });

            modelBuilder.Entity<AccommodationCategory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Charge).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Admission>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccId).HasColumnName("AccID");

                entity.Property(e => e.InDate).HasColumnType("datetime");

                entity.Property(e => e.Luggage).HasColumnType("text");

                entity.Property(e => e.OutDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
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
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Func).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Meals>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccId).HasColumnName("AccID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Charge).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<ServicesOfAcc>(entity =>
            {
                entity.HasKey(e => new { e.IdAccount, e.IdServices });

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.ServicesOfAcc)
                    .HasForeignKey(d => d.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicesOfAcc_Account");

                entity.HasOne(d => d.IdServicesNavigation)
                    .WithMany(p => p.ServicesOfAcc)
                    .HasForeignKey(d => d.IdServices)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicesOfAcc_ListServices");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
