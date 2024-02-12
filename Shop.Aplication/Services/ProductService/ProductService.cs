using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Aplication.Models.Dto;
using Shop.Aplication.Repository;
using Shop.Domain.Entity;

namespace Shop.Aplication.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductReadonlyRepository _productReadonlyRepository;

        private static readonly Dictionary<string, object> _cache = new Dictionary<string, object>();
        private static readonly Dictionary<string, DateTime> _expirationTimes = new Dictionary<string, DateTime>();

        public ProductService(IProductRepository productRepository, IProductReadonlyRepository productReadonlyRepository)
        {
            _productReadonlyRepository = productReadonlyRepository;
            _productRepository = productRepository;
        }

        public async Task  Create(CreateProductInput input)
        {
            Product model = new()
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                quantity = input.quantity,
                CategoryId = input.CategoryId

            };

            await _productRepository.Add(model);

        }

        public async Task<IEnumerable<ProductDto>> GetAll(int? id,double? minprice,double? maxPrice, string? name, int? categoryId, string? categoryName)
        {
            return await _productReadonlyRepository.GetAll(id, minprice, maxPrice, name, categoryId, categoryName);
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
