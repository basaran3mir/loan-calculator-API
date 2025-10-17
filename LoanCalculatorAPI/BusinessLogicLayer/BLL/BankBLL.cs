using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.DAL;
using DataAccessLayer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BLL
{
    public class BankBLL
    {
        private BankDAL _DAL;
        private Mapper _BankMapper;

        public BankBLL(BankDAL dal)
        {
            _DAL = dal;

            var _configLoanApp = new MapperConfiguration(cfg => cfg.CreateMap<Bank, BankModel>().ReverseMap());
            _BankMapper = new Mapper(_configLoanApp);
        }

        public List<BankModel> GetAllBanks()
        {
            List<Bank> BankFromDB = _DAL.GetAllBanks();
            List<BankModel> BankModel = _BankMapper.Map<List<Bank>, List<BankModel>>(BankFromDB);

            return BankModel;
        }

        public BankModel GetBankById(int id)
        {
            var BankEntity = _DAL.GetBankById(id);

            BankModel BankModel = _BankMapper.Map<Bank, BankModel>(BankEntity);

            return BankModel;
        }


        public void AddBank(BankModel BankModel)
        {
            Bank BankEntity = _BankMapper.Map<BankModel, Bank>(BankModel);
            _DAL.AddBank(BankEntity);
        }

        public void RemoveBank(int id)
        {
            _DAL.RemoveBank(id);
        }

    }
}
