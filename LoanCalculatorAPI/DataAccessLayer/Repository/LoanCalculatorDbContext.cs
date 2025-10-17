using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class LoanCalculatorDbContext : DbContext
    {

        public LoanCalculatorDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<LoanApp> LoanApps { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }
    }

}
