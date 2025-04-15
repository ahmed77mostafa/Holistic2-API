using Holistic_2.Data.DTOs;
using Holistic_2.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holistic_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _orderRepo;

        public OrderController(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderRepo.GetOrders();
            if(orders == null)
                return NotFound();
            return Ok(orders);
        }
        [HttpPost]
        public IActionResult PostOrder(OrderRequest orderRequest)
        {
            if(_orderRepo.AddOrder(orderRequest))
                return Ok();
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, OrderWithProduct orderRequest)
        {
            var result = _orderRepo.UpdateOrder(id, orderRequest);
            if(result)
                return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var result = _orderRepo.DeleteOrder(id);
            if(result)
                return Ok();
            return NotFound();
        }
    }
}
