using ETicaretaPI.Domain.Entities;
using ETicaretAPI.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
                => new() { 
                    new() { Id = Guid.NewGuid(),Name="Product 1",Price=100,Stock=10},
                     new() { Id = Guid.NewGuid(),Name="Product 1",Price=200,Stock=10},
                      new() { Id = Guid.NewGuid(),Name="Product 1",Price=300,Stock=10},
                       new() { Id = Guid.NewGuid(),Name="Product 1",Price=400,Stock=10},
                       new() { Id = Guid.NewGuid(),Name="Product 1",Price=500,Stock=10}
                };
    }
}
