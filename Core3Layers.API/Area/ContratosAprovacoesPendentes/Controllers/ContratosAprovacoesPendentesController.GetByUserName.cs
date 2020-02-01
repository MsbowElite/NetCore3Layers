using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3Layers.API.Models;
using Core3LayersAPI.Core.Models;

namespace Core3Layers.API.Area.ContratosAprovacoesPendentes.Controllers
{
    public partial class ContratosAprovacoesPendentesController
    {
        [HttpGet("GetByUserName/{userName}")]
        [ProducesResponseType(typeof(IEnumerable<ConsultarContratosAprovacoesPendentesViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUserName(string userName, 
        [FromQuery]PaginationModel paginationModel,
        [FromServices]IMemoryCache cache)
        {
            try
            {
                string signature = "ContratosAprovacoesPendentesController/GetByUserName/" + userName;
                var cacheControl = ((Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpRequestHeaders)((Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest)Request).Headers).HeaderCacheControl;

                if(cacheControl.Count > 0)
                {
                    cache.Remove(signature);
                }

                var cacheResult = await cache.GetOrCreateAsync(
                    signature, async context =>
                    {
                        context.SetAbsoluteExpiration(TimeSpan.FromSeconds(50));
                        context.SetPriority(CacheItemPriority.Normal);
                        return await _contratosAprovacoesPendentesRepository.GetByUserName(userName);
                    });
                

                if (cacheResult == null)
                {
                    return NotFound();
                }

                return Ok(new PaginatedItemsViewModel<ConsultarContratosAprovacoesPendentesViewModel>
                    (paginationModel.PageIndex, paginationModel.PageSize, cacheResult.Count(), cacheResult.Skip(paginationModel.PageIndex*paginationModel.PageSize).Take(paginationModel.PageSize)));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
