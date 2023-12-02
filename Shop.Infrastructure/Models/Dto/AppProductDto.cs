using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Models.Dto
{
    public class AppProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int quantity { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
