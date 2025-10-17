using DataAccessLayer.Repository.Entities;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAL
{
    public class LoanTypeDAL
    {
        public List<LoanType> GetAllLoanTypes()
        {
            var db = new MyDbContext();
            return db.LoanTypes.ToList();
        }

        public LoanType GetLoanTypeById(int id)
        {
            var db = new MyDbContext();
            LoanType c = new LoanType();
            c = db.LoanTypes.FirstOrDefault(x => x.TypeId == id);

            return c;
        }

        public void AddLoanType(LoanType c)
        {
            var db = new MyDbContext();
            db.Add(c);
            db.SaveChanges();
        }

        public void RemoveLoanType(int id)
        {
            var db = new MyDbContext();
            var existingLoanType = GetLoanTypeById(id);
            if (existingLoanType != null)
            {
                db.Remove(existingLoanType);
                db.SaveChanges();
            }
        }
    }
}
