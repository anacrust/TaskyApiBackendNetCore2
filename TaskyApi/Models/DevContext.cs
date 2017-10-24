using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskyApi.Models
{
    public partial class DevContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Pictures> Pictures { get; set; }
        public virtual DbSet<TaskCategory> TaskCategory { get; set; }
        public virtual DbSet<TaskMultiAddress> TaskMultiAddress { get; set; }
        public virtual DbSet<TaskType> TaskType { get; set; }
        public virtual DbSet<Tasky> Tasky { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserBackgroundCheck> UserBackgroundCheck { get; set; }
        public virtual DbSet<UserLicense> UserLicense { get; set; }
        public virtual DbSet<UserLicenseType> UserLicenseType { get; set; }
        public virtual DbSet<UserM2muserRole> UserM2muserRole { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        // Unable to generate entity type for table 'dbo.userLicenseTypeM2MtaskType'. Please see the warning messages.

        public DevContext(DbContextOptions<DevContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(100);

                entity.Property(e => e.Confirmed).HasColumnName("confirmed");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(100);

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasMaxLength(100);

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.Lng)
                    .HasColumnName("lng")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("postalCode")
                    .HasMaxLength(25);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnName("region")
                    .HasMaxLength(100);

                entity.Property(e => e.Street1)
                    .IsRequired()
                    .HasColumnName("street1")
                    .HasMaxLength(100);

                entity.Property(e => e.Street2)
                    .HasColumnName("street2")
                    .HasMaxLength(100);

                entity.Property(e => e.Street3)
                    .HasColumnName("street3")
                    .HasMaxLength(100);

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .HasColumnName("updated")
                    .IsRowVersion();
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("paymentType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .HasColumnName("updated")
                    .IsRowVersion();
            });

            modelBuilder.Entity<Pictures>(entity =>
            {
                entity.ToTable("pictures");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.PicCdn)
                    .HasColumnName("picCdn")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.PicData).HasColumnName("picData");
            });

            modelBuilder.Entity<TaskCategory>(entity =>
            {
                entity.ToTable("taskCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .HasColumnName("updated")
                    .IsRowVersion();
            });

            modelBuilder.Entity<TaskMultiAddress>(entity =>
            {
                entity.HasKey(e => new { e.TaskId, e.AddressId });

                entity.ToTable("taskMultiAddress");

                entity.Property(e => e.TaskId).HasColumnName("taskId");

                entity.Property(e => e.AddressId).HasColumnName("addressId");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LocationNum).HasColumnName("locationNum");

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .HasColumnName("updated")
                    .IsRowVersion();

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.TaskMultiAddress)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_taskMultiAddress_address");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskMultiAddress)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_taskMultiAddress_task");
            });

            modelBuilder.Entity<TaskType>(entity =>
            {
                entity.ToTable("taskType");

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskCategoryId).HasColumnName("taskCategoryId");

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .HasColumnName("updated")
                    .IsRowVersion();

                entity.HasOne(d => d.TaskCategory)
                    .WithMany(p => p.TaskType)
                    .HasForeignKey(d => d.TaskCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_taskType_taskCategory");
            });

            modelBuilder.Entity<Tasky>(entity =>
            {
                entity.ToTable("tasky");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BackgroundCheckReq).HasColumnName("backgroundCheckReq");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(100);

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.ContactNotes)
                    .HasColumnName("contactNotes")
                    .HasMaxLength(1000);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(100);

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasMaxLength(100);

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatorId).HasColumnName("creatorId");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnName("endTime");

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.LicenseReq).HasColumnName("licenseReq");

                entity.Property(e => e.Lng)
                    .HasColumnName("lng")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.MultiAddressReq).HasColumnName("multiAddressReq");

                entity.Property(e => e.NoAddressReq).HasColumnName("noAddressReq");

                entity.Property(e => e.PaymentNotes)
                    .HasColumnName("paymentNotes")
                    .HasMaxLength(1000);

                entity.Property(e => e.PaymentTypeId).HasColumnName("paymentTypeId");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postalCode")
                    .HasMaxLength(25);

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasMaxLength(100);

                entity.Property(e => e.SingleAddressReq).HasColumnName("singleAddressReq");

                entity.Property(e => e.StartTime).HasColumnName("startTime");

                entity.Property(e => e.Street1)
                    .HasColumnName("street1")
                    .HasMaxLength(100);

                entity.Property(e => e.Street2)
                    .HasColumnName("street2")
                    .HasMaxLength(100);

                entity.Property(e => e.Street3)
                    .HasColumnName("street3")
                    .HasMaxLength(100);

                entity.Property(e => e.TaskTypeId).HasColumnName("taskTypeId");

                entity.Property(e => e.TaskerId).HasColumnName("taskerId");

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .HasColumnName("updated")
                    .IsRowVersion();

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.TaskyCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_user");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Tasky)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_paymentType");

                entity.HasOne(d => d.TaskType)
                    .WithMany(p => p.Tasky)
                    .HasForeignKey(d => d.TaskTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_taskType");

                entity.HasOne(d => d.Tasker)
                    .WithMany(p => p.TaskyTasker)
                    .HasForeignKey(d => d.TaskerId)
                    .HasConstraintName("FK_task_user1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email)
                    .HasName("email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DriverLicenseScanCdn)
                    .HasColumnName("driverLicenseScanCdn")
                    .HasMaxLength(350);

                entity.Property(e => e.DriversLicenseScanData).HasColumnName("driversLicenseScanData");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.HasBackgroundCheck).HasColumnName("hasBackgroundCheck");

                entity.Property(e => e.HasLicense).HasColumnName("hasLicense");

                entity.Property(e => e.IsLocked)
                    .HasColumnName("isLocked")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(75);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2nd)
                    .HasColumnName("phone2nd")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2ndExt)
                    .HasColumnName("phone2ndExt")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneMain)
                    .IsRequired()
                    .HasColumnName("phoneMain")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneMaineExt)
                    .HasColumnName("phoneMaineExt")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePicCdn)
                    .HasColumnName("profilePicCdn")
                    .HasMaxLength(350);

                entity.Property(e => e.ProfilePicData).HasColumnName("profilePicData");

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .HasColumnName("updated")
                    .IsRowVersion();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserBackgroundCheck>(entity =>
            {
                entity.ToTable("userBackgroundCheck");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageScanData).HasColumnName("imageScanData");

                entity.Property(e => e.ImageScaneCdn)
                    .HasColumnName("imageScaneCdn")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Passed).HasColumnName("passed");

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .HasColumnName("updated")
                    .IsRowVersion();

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserBackgroundCheck)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userBackgroundCheck_user");
            });

            modelBuilder.Entity<UserLicense>(entity =>
            {
                entity.ToTable("userLicense");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(100);

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasMaxLength(100);

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageCdn)
                    .HasColumnName("imageCdn")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.ImageScanData).HasColumnName("imageScanData");

                entity.Property(e => e.LicenseTypeId).HasColumnName("licenseTypeId");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasMaxLength(100);

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .HasColumnName("updated")
                    .IsRowVersion();

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.LicenseType)
                    .WithMany(p => p.UserLicense)
                    .HasForeignKey(d => d.LicenseTypeId)
                    .HasConstraintName("FK_userLicense_userLicenseType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLicense)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_userLicense_user");
            });

            modelBuilder.Entity<UserLicenseType>(entity =>
            {
                entity.ToTable("userLicenseType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .HasColumnName("updated")
                    .IsRowVersion();
            });

            modelBuilder.Entity<UserM2muserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.UserRoleId });

                entity.ToTable("userM2MuserRole");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserRoleId).HasColumnName("userRoleId");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .HasColumnName("updated")
                    .IsRowVersion();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserM2muserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userM2MuserRole_user");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.UserM2muserRole)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userM2MuserRole_userRole");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("userRole");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .HasColumnName("updated")
                    .IsRowVersion();
            });
        }
    }
}
