using Core3Layers.Core.Entities;
using Core3Layers.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Layers.API.Area.Customers
{
    public partial class CustomersController
    {
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<CustomerDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            try
            {
                var customers = await _rw.Customer.GetAllCustomersAsync(pageSize, pageIndex);
                var customersMap = _mapper.Map<List<Customer>, List<CustomerDTO>>(customers.Item1);
                return Ok(new PaginatedItemsViewModel<CustomerDTO>(pageIndex, pageSize,
                    customers.Count, customersMap));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
