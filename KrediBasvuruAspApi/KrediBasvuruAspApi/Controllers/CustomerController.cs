using BusinessLogicLayer.BLL;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KrediBasvuruAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerBLL _BLL;

        public CustomerController()
        {
            _BLL = new BusinessLogicLayer.BLL.CustomerBLL();
        }

        [HttpGet]
        public List<CustomerModel> GetAllCustomers()
        {
            return _BLL.GetAllCustomers();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<CustomerModel> GetCustomerById([FromRoute] int id)
        {
            var c = _BLL.GetCustomerById(id);
            return Ok(c);
        }

        [HttpGet]
        [Route("{email}")]
        public ActionResult<CustomerModel> GetCustomerByEmail([FromRoute] string email)
        {
            var c = _BLL.GetCustomerByEmail(email);
            return Ok(c);
        }

        [HttpPost]
        public ActionResult<CustomerModel> AddCustomer([FromBody] CustomerModel customerModel)
        {
            _BLL.AddCustomer(customerModel);
            return Ok(customerModel);
        }

        /*
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<LoanAppModel> UpdateLoanApp([FromRoute] int id, [FromBody] LoanAppModel updatedLoanApp)
        {
            _BLL.UpdateLoanApp(id, updatedLoanApp);
            return Ok(updatedLoanApp);
        }
        */

        [HttpDelete]
        [Route("{id:int}")]
        public void DeleteCustomerFromId([FromRoute] int id)
        {
            _BLL.RemoveCustomer(id);
        }

    }
}
