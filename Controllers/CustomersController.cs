using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Models;

namespace EshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private EshopApi_DBContext _context;

        public CustomersController(EshopApi_DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            return new ObjectResult(_context.Customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer([FromRoute] int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            return Ok();
        }
    }
}
