using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain;
using Shop.Aplication.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Data;

namespace Shop.Aplication.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly AplicationDbContext _db;

        public ProductService(IProductRepository productRepository , AplicationDbContext db)
        {
            _db = db;
            _productRepository = productRepository;
        }

        public async Task  Create(CreateProductInput input)
        {
            Product model = new()
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                quantity = input.quantity
            };

            await _productRepository.Add(model);

        }

        public async Task<IEnumerable<Product>> GetAll(int? id,int? minprice,int? maxPrice, string? name)
        {

           return await _productRepository.GetAll(id, minprice, maxPrice, name);
        }

        public async Task Update(UpdateProductInput input)
        {
            Product model = new()
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                quantity = input.quantity
            };
            await _productRepository.Update(model);

        }

        public async Task Delete(int id)
        {
           var product = await _productRepository.Get(id);

           await _productRepository.Delete(product);

        }

    }
}
