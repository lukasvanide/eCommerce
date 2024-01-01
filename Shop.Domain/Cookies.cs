using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class Cookies
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LoginTime { get; set; }
        [Required]
        public Guid? AccessToken { get; set; }


        [ForeignKey("UserId")]
        public LocalUsers User { get; set; }

    }
}
