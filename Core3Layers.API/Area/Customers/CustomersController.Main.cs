using AutoMapper;
using Core3Layers.Core.Interfaces;
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
        private readonly ICustomerService _customerService;
        private readonly IRepositoryWrapper _rw;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CustomersController(ICustomerService customerService , IRepositoryWrapper rw, IMapper mapper, ILogger<CustomersController> logger)
        {
            _customerService = customerService;
            _rw = rw;
            _mapper = mapper;
            _logger = logger;
        }
    }
}