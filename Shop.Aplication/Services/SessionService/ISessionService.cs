using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Services.SessionService
{
    public interface ISessionService
    {
        public string AccessToken { get; set; }
        Task<int> GetCurrentUserId();
    }
}
