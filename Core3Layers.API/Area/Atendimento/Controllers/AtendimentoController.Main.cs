using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3LayersAPI.Core.Interfaces;
using Core3LayersAPI.Infrastructure.Interfaces;

namespace Core3Layers.API.Area.Atendimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public partial class AtendimentoController : ControllerBase
    {
        private readonly IRepositoryWrapper _rw;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AtendimentoController(IRepositoryWrapper rw, IMapper mapper, ILogger<AtendimentoController> logger)
        {
            _rw = rw;
            _mapper = mapper;
            _logger = logger;
        }
    }
}
