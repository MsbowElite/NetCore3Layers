using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core3LayersAPI.Core.Interfaces;
using Core3LayersAPI.Infrastructure.Interfaces;

namespace Core3Layers.API.Area.ContratosAprovacoesPendentes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public partial class ContratosAprovacoesPendentesController : ControllerBase
    {
        private readonly IRepositoryWrapper _rw;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IContratosAprovacoesPendentesRepository _contratosAprovacoesPendentesRepository;
        public ContratosAprovacoesPendentesController(IRepositoryWrapper rw, IMapper mapper, ILogger<ContratosAprovacoesPendentesController> logger, IContratosAprovacoesPendentesRepository contratosAprovacoesPendentesRepository)
        {
            _rw = rw;
            _mapper = mapper;
            _logger = logger;
            _contratosAprovacoesPendentesRepository = contratosAprovacoesPendentesRepository;
        }
    }
}
