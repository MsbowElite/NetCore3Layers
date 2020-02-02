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
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CustomerDTO customer)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                //var disheMap = _mapper.Map<DishDTO, Entities.Dish>(dish);
                await _customerService.CreateCustomerAsync(customer);

                //dish = _mapper.Map<Entities.Dish, DishDTO>(disheMap);
                //return CreatedAtAction(nameof(GetById), new { customer.Id });
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
