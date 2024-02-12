using Shop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Services.ProductCategoryService
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();

    }
}

