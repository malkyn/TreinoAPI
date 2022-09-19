using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViaCepTeste.Interfaces;
using ViaCepTeste.Models;

namespace ViaCep.Controllers
{
    [Route("api/[controller]")]
    public class CepController : Controller
    {
        private readonly IMemoryCache _cache;
        private const string cep_key = "Cep";
        private readonly ICepCacheService _cacheService;

        public CepController(IMemoryCache cache, ICepCacheService cacheService)
        {
            _cache = cache;
            _cacheService = cacheService;
        }

        [HttpPost("GetCep")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> GetCep([FromBody] CepModel cep, List<CepResult> ceps)
        {
            if (_cache.TryGetValue(cep_key, out List<CepResult> cepsL))
            {
                var result = cepsL.FirstOrDefault(x => x.cep.Replace("-", "") == cep.Cep).Origem = "Cache";
                if (result != null)
                    return Ok(cepsL);
            }
            await _cacheService.SetCache(cep_key, _cache, cep, ceps);
            ceps.FirstOrDefault(x => x.cep.Replace("-", "") == cep.Cep).Origem = "ViaCep";
            return Ok(ceps);
        }

    }
}
