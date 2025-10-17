using BusinessLogicLayer.BLL;
using BusinessLogicLayer.Models;
using DataAccessLayer.Repository.Entities;
using KrediBasvuruAspApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace KrediBasvuruAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private BankBLL _BLL;
        private readonly RedisCacheService _cacheService;

        public BankController(RedisCacheService cacheService, BankBLL bll)
        {
            _BLL = bll;
            _cacheService = cacheService;
        }

        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<List<BankModel>>> GetAllBanks()
        {
            var cachedData = await _cacheService.GetAllAsync();
            var cachedDict = cachedData.ToDictionary(kv => kv.Key, kv => kv.Value); // Convert IEnumerable to Dictionary
            var bankKeys = cachedDict.Keys.Where(key => key.StartsWith("bank")).ToList();

            if (bankKeys.Any())
            {
                var banks = bankKeys.Select(key => new Bank { BankId = int.Parse(key.Substring(4)), BankName = cachedDict[key] }).ToList();
                Console.WriteLine("Redis is here.");
                return Ok(banks);
            }

            Console.WriteLine("Redis is not here.");
            return _BLL.GetAllBanks();
        }



        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<BankModel>> GetBankById([FromRoute] int id)
        {
            var cachedKey = await _cacheService.GetValueAsync("bank" + id.ToString()); //check cache
            if (!string.IsNullOrEmpty(cachedKey))
            {
                var newBank = new Bank
                {
                    BankId = id,
                    BankName = cachedKey
                };
                return Ok(newBank);
            }

            var c = _BLL.GetBankById(id); //go to db
            return Ok(c);
        }

        [HttpPost]
        public async Task<ActionResult<BankModel>> AddBank([FromBody] BankModel BankModel)
        {
            await _cacheService.SetValueAsync("bank"+BankModel.BankId.ToString(),BankModel.BankName); //Add to cache
            _BLL.AddBank(BankModel); //Add to db
            return Ok(BankModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteBankFromId([FromRoute] int id)
        {
            await _cacheService.Clear("bank" + id.ToString()); //Remove from cache
            var bank = _BLL.GetBankById(id);
            _BLL.RemoveBank(id); //Remove from db

            return Ok();
        }


    }

}
