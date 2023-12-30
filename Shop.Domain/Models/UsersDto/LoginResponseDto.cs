using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Models.UsersDto
{
    public class LoginResponseDto
    {
        public LocalUsers user { get; set; }

        public string Token { get; set; }
    }
}
