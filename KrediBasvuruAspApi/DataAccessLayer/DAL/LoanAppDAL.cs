using DataAccessLayer.Repository;
using DataAccessLayer.Repository.Entities;
using Newtonsoft.Json;
using System;

namespace DataAccessLayer.DAL
{
    public class LoanAppDAL
    {
        public List<LoanApp> GetAllLoanApps()
        {
            var db = new MyDbContext();
            return db.LoanApps.ToList();
        }

        public LoanApp GetLoanAppById(int id)
        {
            var db = new MyDbContext();
            LoanApp loanApp = new LoanApp();
            loanApp = db.LoanApps.FirstOrDefault(x => x.AppId == id);

            return loanApp;
        }

        public LoanApp GetLoanAppByCustomerId(int customerId)
        {
            var db = new MyDbContext();
            LoanApp l = new LoanApp();
            l = db.LoanApps.FirstOrDefault(x => x.CustomerID == customerId);

            return l;
        }

        public List<LoanApp> GetLoanAppsByCustomerId(int customerId)
        {
            var db = new MyDbContext();
            return db.LoanApps.Where(x => x.CustomerID == customerId).ToList();
        }


        public void AddLoanApp(LoanApp loanapp)
        {
            var db = new MyDbContext();
            db.Add(loanapp);
            db.SaveChanges();
        }

        public void RemoveLoanApp(int id)
        {
            var db = new MyDbContext();
            var existingLoanApp = GetLoanAppById(id);
            db.Remove(existingLoanApp);
            db.SaveChanges();
        }

        public List<string> GetPopularLoanApps()
        {
            var db = new MyDbContext();
            var loanapps = db.LoanApps.ToList();

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