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

        private readonly LoanCalculatorDbContext _db;

        public LoanTypeDAL(LoanCalculatorDbContext db)
        {
            _db = db;
        }

        public List<LoanType> GetAllLoanTypes()
        {
            return _db.LoanTypes.ToList();
        }

        public LoanType GetLoanTypeById(int id)
        {
            return _db.LoanTypes.FirstOrDefault(x => x.TypeId == id);
        }

        public void AddLoanType(LoanType c)
        {
            _db.Add(c);
            _db.SaveChanges();
        }

        public void RemoveLoanType(int id)
        {
            var existingLoanType = GetLoanTypeById(id);
            if (existingLoanType != null)
            {
                _db.Remove(existingLoanType);
                _db.SaveChanges();
            }
        }
    }
}
