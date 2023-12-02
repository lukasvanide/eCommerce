using Shop.Aplication.Models.Dto;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shop.Aplication.Repository
{
    public interface IProductReadonlyRepository
    {
        Task<IEnumerable<ProductDto>> GetAll(int? id, int? minPrice, int? maxPrice, string? name, int? categoryId, string? categoryName);
    }
}
