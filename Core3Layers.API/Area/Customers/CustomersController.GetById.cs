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
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var customer = await _rw.Customer.GetCustomerByIdAsync(id);

                if (customer == null)
                {
                    return NotFound();
                }

                //var disheMap = _mapper.Map<Entities.Dish, DishDTO>(dishe);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
