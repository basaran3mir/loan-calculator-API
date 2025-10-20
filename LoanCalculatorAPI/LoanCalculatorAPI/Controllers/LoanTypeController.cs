using BusinessLogicLayer.BLL;
using BusinessLogicLayer.Models;
using DataAccessLayer.Repository.Entities;
using KrediBasvuruAspApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace KrediBasvuruAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanTypeController : ControllerBase
    {
        private LoanTypeBLL _BLL;
        private readonly RedisCacheService _cacheService;

        public LoanTypeController(RedisCacheService cacheService, LoanTypeBLL bll)
        {
            _BLL = bll;
            _cacheService = cacheService;
        }

        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<List<LoanTypeModel>>> GetAllLoanTypes()
        {
            var cachedData = await _cacheService.GetAllAsync();
            var cachedDict = cachedData.ToDictionary(kv => kv.Key, kv => kv.Value); // Convert IEnumerable to Dictionary
            var LoanTypeKeys = cachedDict.Keys.Where(key => key.StartsWith("type")).ToList();

            if (LoanTypeKeys.Any())
            {
                var LoanTypes = LoanTypeKeys.Select(key => new LoanType { TypeId = int.Parse(key.Substring(4)), TypeName = cachedDict[key] }).ToList();
                Console.WriteLine("Redis is here.");
                return Ok(LoanTypes);
            }

            Console.WriteLine("Redis is not here.");
            return _BLL.GetAllLoanTypes();
        }



        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<LoanTypeModel>> GetLoanTypeById([FromRoute] int id)
        {
            var cachedKey = await _cacheService.GetValueAsync("type" + id.ToString()); //check cache
            if (!string.IsNullOrEmpty(cachedKey))
            {
                var newLoanType = new LoanType
                {
                    TypeId = id,
                    TypeName = cachedKey
                };
                return Ok(newLoanType);
            }

            var c = _BLL.GetLoanTypeById(id); //go to db
            return Ok(c);
        }

        [HttpPost]
        public async Task<ActionResult<LoanTypeModel>> AddLoanType([FromBody] LoanTypeModel LoanTypeModel)
        {
            await _cacheService.SetValueAsync("type" + LoanTypeModel.TypeId.ToString(), LoanTypeModel.TypeName); //Add to cache
            _BLL.AddLoanType(LoanTypeModel); //Add to db
            return Ok(LoanTypeModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteLoanTypeFromId([FromRoute] int id)
        {
            await _cacheService.Clear("type" + id.ToString()); //Remove from cache
            var LoanType = _BLL.GetLoanTypeById(id);
            _BLL.RemoveLoanType(id); //Remove from db

            return Ok();
        }


    }

}
