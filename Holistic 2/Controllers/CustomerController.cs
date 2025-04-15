using Holistic_2.Data.DTOs;
using Holistic_2.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holistic_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        [HttpPost]
        public IActionResult AddCustomer(CustomerRequest customerDto)
        {
            if(_customerRepo.AddCustomer(customerDto))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var result = _customerRepo.GetCustomerById(id);
            if(result != null)
                return Ok(result);
            return NotFound();
        }
    }
}
