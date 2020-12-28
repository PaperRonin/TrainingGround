using Microsoft.EntityFrameworkCore;
using WebHW.Models;

#nullable disable

namespace WebHW.DataBase
{
    public class WebHwDbContext : DbContext, IWebHWContext
    {
        public WebHwDbContext(DbContextOptions<WebHwDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Customer)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Executor)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Priority)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectEmployee>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.EmployeeId });

                entity.HasIndex(e => e.EmployeeId, "IX_ProjectEmployees_EmployeeId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ProjectEmployees)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectEmployees)
                    .HasForeignKey(d => d.ProjectId);
            });

        }

    }
}
