using ETicaretaPI.Domain.Entities;
using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
          await  _productWriteRepository.AddRangeAsync(new()
            {
                new() {Id = Guid.NewGuid(), Name = "Product 1",Price=100, CreatedDate=DateTime.Now, Stock=10},
                new() {Id = Guid.NewGuid(), Name = "Product 2",Price=200, CreatedDate=DateTime.Now, Stock=20},
                new() {Id = Guid.NewGuid(), Name = "Product 3",Price=300, CreatedDate=DateTime.Now, Stock=30},
            });
            var count = await  _productWriteRepository.SaveAsync();
        }

        [HttpGet("id")]

        public async Task<IActionResult> Get(string id)
        {
          Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
