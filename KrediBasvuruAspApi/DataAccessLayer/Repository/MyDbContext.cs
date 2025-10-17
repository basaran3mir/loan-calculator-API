using DataAccessLayer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccessLayer.Repository
{
    public class MyDbContext:DbContext
    {
        public MyDbContext()
        {

        }
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-0HSD5TG\\SQLEXPRESS;Database=LoanAppDatabase;Integrated Security=True;TrustServerCertificate=true;");
            }
        }

        public DbSet<LoanApp> LoanApps { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }

    }
}
