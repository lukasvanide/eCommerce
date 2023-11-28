using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Aplication.Models.Dto;
using Shop.Domain;

namespace Shop.Aplication.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll(int? id, int? minPrice,int? maxPrice, string? name, int? categoryId, string? categoryName);

        Task Create(CreateProductInput input);

        Task Update(UpdateProductInput input);

        Task Delete(int id);

    }
}
