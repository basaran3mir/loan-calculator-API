using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.DAL;
using DataAccessLayer.Repository;
using DataAccessLayer.Repository.Entities;
using System;


namespace BusinessLogicLayer.BLL
{
    public class LoanAppBLL
    {
        private LoanAppDAL _DAL;
        private Mapper _LoanAppMapper;

        public LoanAppBLL()
        {
            _DAL = new LoanAppDAL();

            var _configLoanApp = new MapperConfiguration(cfg => cfg.CreateMap<LoanApp, LoanAppModel>().ReverseMap());
            _LoanAppMapper = new Mapper(_configLoanApp);
        }

        public List<LoanAppModel> GetAllLoanApps()
        {
            List<LoanApp> LoanAppFromDB = _DAL.GetAllLoanApps();
            List<LoanAppModel> LoanAppModel = _LoanAppMapper.Map<List<LoanApp>, List<LoanAppModel>>(LoanAppFromDB);

            return LoanAppModel;
        }

        public LoanAppModel GetLoanAppById(int id)
        {
            var LoanAppEntity = _DAL.GetLoanAppById(id);

            LoanAppModel LoanAppModel = _LoanAppMapper.Map<LoanApp, LoanAppModel>(LoanAppEntity);

            return LoanAppModel;
        }

        public LoanAppModel GetLoanAppByCustomerId(int customerId)
        {
            var loanAppEntity = _DAL.GetLoanAppByCustomerId(customerId);
            LoanAppModel loanAppModel = _LoanAppMapper.Map<LoanApp, LoanAppModel>(loanAppEntity);

            return loanAppModel;
        }

        public List<LoanAppModel> GetLoanAppsByCustomerId(int customerId)
        {
            List<LoanApp> LoanAppFromDB = _DAL.GetLoanAppsByCustomerId(customerId);
            List<LoanAppModel> LoanAppModel = _LoanAppMapper.Map<List<LoanApp>, List<LoanAppModel>>(LoanAppFromDB);

            return LoanAppModel;
        }

        public void AddLoanApp(LoanAppModel loanAppModel)
        {
            LoanApp LoanAppEntity = _LoanAppMapper.Map<LoanAppModel, LoanApp>(loanAppModel);
            _DAL.AddLoanApp(LoanAppEntity);
        }

        public void RemoveLoanApp(int id)
        {
            _DAL.RemoveLoanApp(id);
        }

        public List<string> GetPopularLoanApps()
        {
            return _DAL.GetPopularLoanApps();
        }

    }
}