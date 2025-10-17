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
        public List<Customer> GetAllCustomers()
        {
            var db = new MyDbContext();
            return db.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            var db = new MyDbContext();
            Customer c = new Customer();
            c = db.Customers.FirstOrDefault(x => x.CustomerID == id);

            return c;
        }

        public Customer GetCustomerByEmail(string email)
        {
            var db = new MyDbContext();
            Customer c = new Customer();
            c = db.Customers.FirstOrDefault(x => x.Email == email);

            return c;
        }

        public void AddCustomer(Customer c)
        {
            var db = new MyDbContext();
            db.Add(c);
            db.SaveChanges();
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
            var db = new MyDbContext();
            var existingCustomer = GetCustomerById(id);
            db.Remove(existingCustomer);
            db.SaveChanges();
        }
    }
}
