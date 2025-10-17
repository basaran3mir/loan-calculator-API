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
    public class LoanTypeBLL
    {
        private LoanTypeDAL _DAL;
        private Mapper _LoanTypeMapper;

        public LoanTypeBLL()
        {
            _DAL = new LoanTypeDAL();

            var _configLoanApp = new MapperConfiguration(cfg => cfg.CreateMap<LoanType, LoanTypeModel>().ReverseMap());
            _LoanTypeMapper = new Mapper(_configLoanApp);
        }

        public List<LoanTypeModel> GetAllLoanTypes()
        {
            List<LoanType> LoanTypeFromDB = _DAL.GetAllLoanTypes();
            List<LoanTypeModel> LoanTypeModel = _LoanTypeMapper.Map<List<LoanType>, List<LoanTypeModel>>(LoanTypeFromDB);

            return LoanTypeModel;
        }

        public LoanTypeModel GetLoanTypeById(int id)
        {
            var LoanTypeEntity = _DAL.GetLoanTypeById(id);

            LoanTypeModel LoanTypeModel = _LoanTypeMapper.Map<LoanType, LoanTypeModel>(LoanTypeEntity);

            return LoanTypeModel;
        }


        public void AddLoanType(LoanTypeModel LoanTypeModel)
        {
            LoanType LoanTypeEntity = _LoanTypeMapper.Map<LoanTypeModel, LoanType>(LoanTypeModel);
            _DAL.AddLoanType(LoanTypeEntity);
        }

        public void RemoveLoanType(int id)
        {
            _DAL.RemoveLoanType(id);
        }
    }
}
