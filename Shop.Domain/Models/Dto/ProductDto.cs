using Shop.Domain;
using System.ComponentModel.DataAnnotations;

namespace Shop.Aplication.Models.Dto
{
    public class ProductDto 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public double Price { get; set; }

        public int quantity { get; set; }

        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

    }
}

