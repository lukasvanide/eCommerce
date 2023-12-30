

using System.ComponentModel.DataAnnotations;

namespace Shop.Aplication.Models.Dto
{
    public class CreateProductInput
    {
        public int Id { get; internal set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int Price { get; set; }

        public int quantity { get; set; }      

        public int CategoryId { get; set; }
    }
}
