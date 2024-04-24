using Authentication.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Authentication.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.ToTable("UserInfo");
                entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.CreatedDate);
            });

            modelBuilder.Entity<UserInfo>().HasData(
        new UserInfo
        {
            UserId = 1,
            DisplayName = "Kemi Mo",
            UserName = "Admin",
            Email = "admin@abc.com",
            Password = "$admin@2022",
            CreatedDate = new DateTime(2024, 4, 24, 14, 47, 58, 207)
        }

    );







            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");
                entity.HasKey(e => e.EmployeeID); // Define the primary key
                entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");
                entity.Property(e => e.NationalIDNumber).HasMaxLength(15).IsUnicode(false);
                entity.Property(e => e.EmployeeName).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.LoginID).HasMaxLength(256).IsUnicode(false);
                entity.Property(e => e.JobTitle).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.BirthDate); // DateTime properties should not be configured with IsUnicode(false)
                entity.Property(e => e.MaritalStatus).HasMaxLength(1).IsUnicode(false);
                entity.Property(e => e.Gender).HasMaxLength(1).IsUnicode(false);
                entity.Property(e => e.HireDate); // DateTime properties should not be configured with IsUnicode(false)
                entity.Property(e => e.VacationHours); // Not a string property, so it should not be configured with IsUnicode(false)
                entity.Property(e => e.SickLeaveHours); // Not a string property, so it should not be configured with IsUnicode(false)
                entity.Property(e => e.RowGuid).IsUnicode(false); // Guid properties should not be configured with MaxLength
                entity.Property(e => e.ModifiedDate); // DateTime properties should not be configured with IsUnicode(false)


            });

            modelBuilder.Entity<Employee>().HasData(
       new Employee
       {
           EmployeeID = 1,
           NationalIDNumber = "295847284",
           EmployeeName = "Michael Westover",
           LoginID = "adventure-works\\ken0",
           JobTitle = "Vice President of Sales",
           BirthDate = new DateTime(1969, 1, 29),
           MaritalStatus = "S",
           Gender = "M",
           HireDate = new DateTime(2009, 1, 14),
           VacationHours = 99,
           SickLeaveHours = 69,
           RowGuid = new Guid("f01251e5-96a3-448d-981e-0f99d789110d"),
           ModifiedDate = new DateTime(2014, 6, 30)
       },
       new Employee
       {
           EmployeeID = 2,
           NationalIDNumber = "245797967",
           EmployeeName = "Raeann Santos",
           LoginID = "adventure-works\\terri0",
           JobTitle = "Vice President of Engineering",
           BirthDate = new DateTime(1971, 8, 1),
           MaritalStatus = "S",
           Gender = "F",
           HireDate = new DateTime(2008, 1, 31),
           VacationHours = 1,
           SickLeaveHours = 20,
           RowGuid = new Guid("45e8f437-670d-4409-93cb-f9424a40d6ee"),
           ModifiedDate = new DateTime(2014, 6, 30)
       },
       new Employee
       {
           EmployeeID = 3,
           NationalIDNumber = "509647174",
           EmployeeName = "Pamela Wambsgans",
           LoginID = "adventure-works\\roberto0",
           JobTitle = "Engineering Manager",
           BirthDate = new DateTime(1974, 11, 12),
           MaritalStatus = "M",
           Gender = "M",
           HireDate = new DateTime(2007, 11, 11),
           VacationHours = 2,
           SickLeaveHours = 21,
           RowGuid = new Guid("9bbbfb2c-efbb-4217-9ab7-f97689328841"),
           ModifiedDate = new DateTime(2014, 6, 30)
       });

            base.OnModelCreating(modelBuilder);
        }
    }
}
