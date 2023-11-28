using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Shop.Domain.Repositories
{
    public interface IProductRepository
    {
        Task Add(Product product);

        Task Update(Product product);

        Task Delete(Product product);

        Task<IEnumerable<Product>> GetAll(int? id,int? minPrice,int? maxPrice ,string? name ,int? categoryId);

        Task<Product> Get(int id);

    }
}
