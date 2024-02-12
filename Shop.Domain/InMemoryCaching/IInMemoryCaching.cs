using Shop.Aplication.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Cashing
{
    public interface  IInMemoryCaching<T> 
    {
        Task Set(string key, T value, TimeSpan expiration);

        Task<T> Get(string key);


    }
}
