using GatewayAPI.Models;
using GatewayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepo<int, ProductDTO> _repo;
        public ProductController(IRepo<int, ProductDTO> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _repo.GetAll();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var products = await _repo.Get(id);
            if (products == null)
                return NotFound();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ProductDTO product)
        {
            var prod = await _repo.Insert(product);
            return Ok(prod);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDTO product)
        {
            var prod = await _repo.Update(product);
            if (prod == null)
                return NotFound();
            return Ok(prod);
        }

        [HttpDelete]
        public async Task<IActionResult> Deletet(int id)
        {
            var prod = await _repo.Delete(id);
            //here
            if (prod != null)
                return NotFound();
            return Ok(prod);
        }
    }
}
