using Core3LayersAPI.Core.Entities;
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
        [ProducesResponseType(typeof(Customer), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                //var disheMap = _mapper.Map<DishDTO, Entities.Dish>(dish);
                await _rw.Customer.CreateCustomerAsync(customer);

                //dish = _mapper.Map<Entities.Dish, DishDTO>(disheMap);
                return CreatedAtAction(nameof(GetById), new { customer.Id }, customer);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
