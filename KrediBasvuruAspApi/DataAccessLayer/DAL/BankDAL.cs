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
        public List<Bank> GetAllBanks()
        {
            var db = new MyDbContext();
            return db.Banks.ToList();
        }

        public Bank GetBankById(int id)
        {
            var db = new MyDbContext();
            Bank c = new Bank();
            c = db.Banks.FirstOrDefault(x => x.BankId == id);

            return c;
        }

        public void AddBank(Bank c)
        {
            var db = new MyDbContext();
            db.Add(c);
            db.SaveChanges();
        }

        public void RemoveBank(int id)
        {
            var db = new MyDbContext();
            var existingBank = GetBankById(id);
            if (existingBank != null )
            {
                db.Remove(existingBank);
                db.SaveChanges();
            }
        }

    }
}
