using Shop.Aplication.Repository;
using Shop.Domain;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Services.SessionService
{
    public class SessionService : ISessionService
    {
        public string AccessToken { get; set; }

        readonly ICookieRepository _cookieRepository;
        
        public SessionService(ICookieRepository cookieRepository)
        {
            _cookieRepository = cookieRepository;

        }   
        public async Task<int> GetCurrentUserId()
        {
            var cookies = await _cookieRepository.GetCookiesByAccessToken(Guid.Parse(AccessToken));

            return cookies.UserId;

        }
    }
}
