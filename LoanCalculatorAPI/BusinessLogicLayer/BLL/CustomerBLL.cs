using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.DAL;
using DataAccessLayer.Repository;
using DataAccessLayer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BLL
{
    public class CustomerBLL
    {
        private CustomerDAL _DAL;
        private Mapper _CustomerMapper;

        public CustomerBLL(CustomerDAL dal)
        {
            _DAL = dal;

            var _configLoanApp = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerModel>().ReverseMap());
            _CustomerMapper = new Mapper(_configLoanApp);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            List<Customer> CustomerFromDB = _DAL.GetAllCustomers();
            List<CustomerModel> CustomerModel = _CustomerMapper.Map<List<Customer>, List<CustomerModel>>(CustomerFromDB);

            return CustomerModel;
        }

        public CustomerModel GetCustomerById(int id)
        {
            var CustomerEntity = _DAL.GetCustomerById(id);

            CustomerModel CustomerModel = _CustomerMapper.Map<Customer, CustomerModel>(CustomerEntity);

            return CustomerModel;
        }

        public CustomerModel GetCustomerByEmail(string email)
        {
            var CustomerEntity = _DAL.GetCustomerByEmail(email);
            CustomerModel CustomerModel = _CustomerMapper.Map<Customer, CustomerModel>(CustomerEntity);

            return CustomerModel;
        }

        public void AddCustomer(CustomerModel customerModel)
        {
            if(IsEmailUnique(customerModel.Email))
            {
                Customer CustomerEntity = _CustomerMapper.Map<CustomerModel, Customer>(customerModel);
                _DAL.AddCustomer(CustomerEntity);
            }
            else
            {
                /*
                string errorMessage = "E-mail adresi kullanımdadır. Farklı bir e-mail adresi seçiniz.";
                throw new Exception(errorMessage);
                */
                return;
            }
        }
        /*
        public LoanAppModel UpdateLoanApp(int id, LoanAppModel updatedLoanAppModel)
        {
            LoanApp updatedLoanApp = _LoanAppMapper.Map<LoanAppModel, LoanApp>(updatedLoanAppModel); 
            _DAL.UpdateLoanApp(id, updatedLoanApp);
            return updatedLoanAppModel;
        }
        */
        public void RemoveCustomer(int id)
        {
            _DAL.RemoveCustomer(id);
        }

        public bool IsEmailUnique(string email)
        {
            var customer = _DAL.GetCustomerByEmail(email);
            return (customer == null);
        }

    }
}
