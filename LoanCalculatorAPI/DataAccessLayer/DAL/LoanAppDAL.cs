using DataAccessLayer.Repository;
using DataAccessLayer.Repository.Entities;
using System;

namespace DataAccessLayer.DAL
{
    public class LoanAppDAL
    {

        private readonly LoanCalculatorDbContext _db;

        public LoanAppDAL(LoanCalculatorDbContext db)
        {
            _db = db;
        }

        public List<LoanApp> GetAllLoanApps()
        {
            return _db.LoanApps.ToList();
        }

        public LoanApp GetLoanAppById(int id)
        {
            return _db.LoanApps.FirstOrDefault(x => x.AppId == id);
        }

        public LoanApp GetLoanAppByCustomerId(int customerId)
        {
            return _db.LoanApps.FirstOrDefault(x => x.CustomerID == customerId);
        }

        public List<LoanApp> GetLoanAppsByCustomerId(int customerId)
        {
            return _db.LoanApps.Where(x => x.CustomerID == customerId).ToList();
        }


        public void AddLoanApp(LoanApp loanapp)
        {
            _db.Add(loanapp);
            _db.SaveChanges();
        }

        public void RemoveLoanApp(int id)
        {
            var existingLoanApp = GetLoanAppById(id);
            _db.Remove(existingLoanApp);
            _db.SaveChanges();
        }

        public List<string> GetPopularLoanApps()
        {
            var loanapps = _db.LoanApps.ToList();

            var popularLoanApps = loanapps
                .GroupBy(l => new { l.Term, l.Amount })
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => $"{(int) g.Key.Amount} TL Kredi, {g.Key.Term} Ay Vade")
                .ToList();

            return popularLoanApps;
        }


    }
}