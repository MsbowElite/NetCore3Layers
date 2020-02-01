using AutoMapper;
using Core3LayersAPI.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Core3Layers.API.Area.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public partial class CustomersController : ControllerBase
    {
        private readonly IRepositoryWrapper _rw;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CustomersController(IRepositoryWrapper rw, IMapper mapper, ILogger<CustomersController> logger)
        {
            _rw = rw;
            _mapper = mapper;
            _logger = logger;
        }
    }
}