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
          await  _productWriteRepository.AddAsync(new() {Name="C product", Price = 1500F,Stock = 10,CreatedDate=DateTime.UtcNow });
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("id")]

        public async Task<IActionResult> Get(string id)
        {
          Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
