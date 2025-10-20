using BusinessLogicLayer.BLL;
using BusinessLogicLayer.Models;
using DataAccessLayer.Repository;
using DataAccessLayer.Repository.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KrediBasvuruAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanAppController : ControllerBase
    {

        private LoanAppBLL _BLL;

        public LoanAppController(LoanAppBLL bll)
        {
            _BLL = bll;
        }

        [HttpGet]
        public List<LoanAppModel> GetAllLoanApps()
        {
            return _BLL.GetAllLoanApps();
        }


        [HttpGet]
        [Route("customerid/{customerId}")]
        public ActionResult<LoanAppModel> GetLoanAppByCustomerId([FromRoute] int customerId)
        {
            var loanApp = _BLL.GetLoanAppByCustomerId(customerId);
            return Ok(loanApp);
        }

        [HttpGet]
        [Route("customerid/{customerId}/all")]
        public List<LoanAppModel> GetLoanAppsByCustomerId([FromRoute] int customerId)
        {
            return _BLL.GetLoanAppsByCustomerId(customerId);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<LoanAppModel> GetLoanAppById([FromRoute] int id)
        {
            var c = _BLL.GetLoanAppById(id);
            return Ok(c);
        }

        [HttpPost]
        public ActionResult<LoanAppModel> AddLoanApp([FromBody] LoanAppModel loanAppModel)
        {
            _BLL.AddLoanApp(loanAppModel);
            return Ok(loanAppModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public void DeleteLoanAppFromId([FromRoute] int id)
        {
            _BLL.RemoveLoanApp(id);
        }

        [HttpGet]
        [Route("populars")]
        public List<string> GetPopularLoanApps()
        {
            return _BLL.GetPopularLoanApps();
        }

    }
}
