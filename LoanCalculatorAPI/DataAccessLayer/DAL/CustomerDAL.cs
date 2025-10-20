using DataAccessLayer.Repository.Entities;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAL
{
    public class CustomerDAL
    {

        private readonly LoanCalculatorDbContext _db;

        public CustomerDAL(LoanCalculatorDbContext db)
        {
            _db = db;
        }

        public List<Customer> GetAllCustomers()
        {
            return _db.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _db.Customers.FirstOrDefault(x => x.CustomerID == id); ;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _db.Customers.FirstOrDefault(x => x.Email == email);
        }

        public void AddCustomer(Customer c)
        {
            _db.Add(c);
            _db.SaveChanges();
        }
        /*
        public LoanApp UpdateLoanApp(int id, LoanApp updatedLoanApp)
        {
            var db = new LoanAppDbContext();
            var existingLoanApp = GetLoanAppById(id);

            existingLoanApp.Email = updatedLoanApp.Email;
            existingLoanApp.NameSurname = updatedLoanApp.NameSurname;
            existingLoanApp.BankName = updatedLoanApp.BankName;
            existingLoanApp.LoanType = updatedLoanApp.LoanType;
            existingLoanApp.InstallmentAmount = updatedLoanApp.InstallmentAmount;
            existingLoanApp.LoanTerm = updatedLoanApp.LoanTerm;

            db.SaveChanges();

            return updatedLoanApp;
        }
        */
        public void RemoveCustomer(int id)
        {
            var existingCustomer = GetCustomerById(id);
            _db.Remove(existingCustomer);
            _db.SaveChanges();
        }
    }
}
