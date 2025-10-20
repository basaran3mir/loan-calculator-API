using DataAccessLayer.Repository.Entities;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAL
{
    public class BankDAL
    {
        private readonly LoanCalculatorDbContext _db;

        public BankDAL(LoanCalculatorDbContext db)
        {
            _db = db;
        }

        public List<Bank> GetAllBanks()
        {
            return _db.Banks.ToList();
        }

        public Bank GetBankById(int id)
        {
            return _db.Banks.FirstOrDefault(x => x.BankId == id); ;
        }

        public void AddBank(Bank c)
        {
            _db.Add(c);
            _db.SaveChanges();
        }

        public void RemoveBank(int id)
        {
            var existingBank = GetBankById(id);
            if (existingBank != null )
            {
                _db.Remove(existingBank);
                _db.SaveChanges();
            }
        }

    }
}
