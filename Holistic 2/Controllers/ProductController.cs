using Holistic_2.Data.DTOs;
using Holistic_2.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holistic_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        [HttpPost]
        public IActionResult AddProduct(ProductDto productDto)
        {
            if (_productRepo.AddProduct(productDto))
                return Ok();
            else return BadRequest();
        }
    }
}
