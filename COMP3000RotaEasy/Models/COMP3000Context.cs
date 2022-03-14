using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace COMP3000RotaEasy.Models
{
    public partial class COMP3000Context : DbContext
    {
        public COMP3000Context()
        {
        }

        public COMP3000Context(DbContextOptions<COMP3000Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Holidays> Holidays { get; set; }
        public virtual DbSet<OpeningHours> OpeningHours { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Shifts> Shifts { get; set; }
        public virtual DbSet<Sickdays> Sickdays { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }
        public virtual DbSet<UserAvailability> UserAvailability { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersEvents> UsersEvents { get; set; }
        public virtual DbSet<UsersHols> UsersHols { get; set; }
        public virtual DbSet<UsersRoles> UsersRoles { get; set; }
        public virtual DbSet<UsersShifts> UsersShifts { get; set; }
        public virtual DbSet<UsersSickdays> UsersSickdays { get; set; }
        public virtual DbSet<UsersStores> UsersStores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-FG64E94G;Database=COMP3000;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("pk_events");

                entity.ToTable("events");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.EventDescription)
                    .HasColumnName("event_description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EventEnd)
                    .HasColumnName("event_end")
                    .HasColumnType("date");

                entity.Property(e => e.EventName)
                    .HasColumnName("event_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventStart)
                    .HasColumnName("event_start")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Holidays>(entity =>
            {
                entity.HasKey(e => e.HolidayId)
                    .HasName("pk_holidays");

                entity.ToTable("holidays");

                entity.Property(e => e.HolidayId).HasColumnName("holiday_id");

                entity.Property(e => e.HolidayEnd)
                    .HasColumnName("holiday_end")
                    .HasColumnType("date");

                entity.Property(e => e.HolidayName)
                    .HasColumnName("holiday_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.HolidayStart)
                    .HasColumnName("holiday_start")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<OpeningHours>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("opening_hours");

                entity.Property(e => e.ClosingTimes)
                    .IsRequired()
                    .HasColumnName("closing_times")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DayOfWeek)
                    .IsRequired()
                    .HasColumnName("day_of_week")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpeningTimes)
                    .IsRequired()
                    .HasColumnName("opening_times")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Store)
                    .WithMany()
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_opening_hours_storeID");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("pk_roles");

                entity.ToTable("roles");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.ContractedHours).HasColumnName("contracted_hours");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("role_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Shifts>(entity =>
            {
                entity.HasKey(e => e.ShiftId)
                    .HasName("pk_shifts");

                entity.ToTable("shifts");

                entity.Property(e => e.ShiftId).HasColumnName("shift_id");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.ShiftDate)
                    .HasColumnName("shift_date")
                    .HasColumnType("date");

                entity.Property(e => e.StartTime).HasColumnName("start_time");
            });

            modelBuilder.Entity<Sickdays>(entity =>
            {
                entity.HasKey(e => e.SickdayId)
                    .HasName("pk_sickdays");

                entity.ToTable("sickdays");

                entity.Property(e => e.SickdayId).HasColumnName("sickday_id");

                entity.Property(e => e.PaidHours).HasColumnName("paid_hours");

                entity.Property(e => e.SickEnd)
                    .HasColumnName("sick_end")
                    .HasColumnType("date");

                entity.Property(e => e.SickStart)
                    .HasColumnName("sick_start")
                    .HasColumnType("date");

                entity.Property(e => e.UnpaidHours).HasColumnName("unpaid_hours");
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("pk_stores");

                entity.ToTable("stores");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.StoreAddress)
                    .HasColumnName("store_address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StoreLocation)
                    .HasColumnName("store_location")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .HasColumnName("store_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreZipCode)
                    .HasColumnName("store_zip_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAvailability>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_availability");

                entity.Property(e => e.DayOfWeek)
                    .HasColumnName("day_of_week")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.IsAvailable).HasColumnName("is_available");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_availability");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk_user");

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ethnicity)
                    .HasColumnName("ethnicity")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAdd)
                    .IsRequired()
                    .HasColumnName("home_add")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoHolHours).HasColumnName("no_hol_hours");

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasColumnName("phone_no")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("user_password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasColumnName("user_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersEvents>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.EventId })
                    .HasName("pk_users_events");

                entity.ToTable("users_events");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.UsersEvents)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_events_event");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersEvents)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_events_user");
            });

            modelBuilder.Entity<UsersHols>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.HolidayId })
                    .HasName("pk_users_hols");

                entity.ToTable("users_hols");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.HolidayId).HasColumnName("holiday_id");

                entity.HasOne(d => d.Holiday)
                    .WithMany(p => p.UsersHols)
                    .HasForeignKey(d => d.HolidayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_hols_hols");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersHols)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_hols_user");
            });

            modelBuilder.Entity<UsersRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("pk_users_roles");

                entity.ToTable("users_roles");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_roles_role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_roles_user");
            });

            modelBuilder.Entity<UsersShifts>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ShiftId })
                    .HasName("pk_user_shifts");

                entity.ToTable("users_shifts");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ShiftId).HasColumnName("shift_id");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.UsersShifts)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_shifts_shift");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersShifts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_shifts_user");
            });

            modelBuilder.Entity<UsersSickdays>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SickdayId })
                    .HasName("pk_users_sickday");

                entity.ToTable("users_sickdays");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.SickdayId).HasColumnName("sickday_id");

                entity.HasOne(d => d.Sickday)
                    .WithMany(p => p.UsersSickdays)
                    .HasForeignKey(d => d.SickdayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_sickday_sick");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersSickdays)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_sickday_user");
            });

            modelBuilder.Entity<UsersStores>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.StoreId })
                    .HasName("pk_users_stores");

                entity.ToTable("users_stores");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.UsersStores)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_stores_store");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersStores)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_stores_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
