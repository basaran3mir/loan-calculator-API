using BusinessLogicLayer.Models;
using KrediBasvuruAspApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace KrediBasvuruAspApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class CacheController : ControllerBase
    {
        private readonly RedisCacheService _cacheService;

        public CacheController(RedisCacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet("cache/{key}")]
        public async Task<IActionResult> Get(string key)
        {
            return Ok(await _cacheService.GetValueAsync(key));
        }

        [HttpGet("cache/all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cacheService.GetAllAsync());
        }

        [HttpPost("cache")]
        public async Task<IActionResult> Post([FromBody] string key, string value)
        {
            await _cacheService.SetValueAsync(key, value);
            return Ok();
        }

        [HttpDelete("cache/{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            await _cacheService.Clear(key);
            return Ok();
        }
    }
}
