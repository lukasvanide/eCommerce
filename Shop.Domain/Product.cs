using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace Shop.Domain
{

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int quantity { get; set; }

        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category Category { get; set; } 
    }
}
