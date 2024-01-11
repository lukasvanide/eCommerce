using Shop.Aplication.Services.SessionService;
using Shop.Domain.Exceptions;

namespace Shop.Middlewear
{
    public class SessionMiddleware : IMiddleware
    {

        private readonly ISessionService _sessionService;
        public SessionMiddleware(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var sessionService = context.RequestServices.GetService<ISessionService>();
            if (context.Request.Cookies.TryGetValue("cookieees", out var accessToken) && !string.IsNullOrEmpty(accessToken))
            {
                sessionService.AccessToken = accessToken;
            }
            await next(context);
        }
    }
}
