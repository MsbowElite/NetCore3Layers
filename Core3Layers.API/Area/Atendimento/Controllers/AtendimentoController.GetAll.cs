using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3Layers.API.Models;
using Core3LayersAPI.Core.Models;

namespace Core3Layers.API.Area.Atendimento.Controllers
{
    public partial class AtendimentoController
    {
        //[HttpGet]
        //[ProducesResponseType(typeof(PaginatedItemsViewModel<AtendimentoDTO>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAll([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        //{
        //    try
        //    {
        //        var atendimentos = await _rw.Atendimento.GetAllAtendimentoAsync(pageSize, pageIndex);
        //        var atendimentosMap = _mapper.Map<IEnumerable<Data.Entities.Atendimento>, IEnumerable<AtendimentoDTO>>(atendimentos.Item1);
        //        return Ok(new PaginatedItemsViewModel<AtendimentoDTO>(pageIndex, pageSize, 
        //            atendimentos.Count, atendimentosMap));
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogWarning(ex.Message);
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}
    }
}
