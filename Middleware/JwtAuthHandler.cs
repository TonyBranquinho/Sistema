using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Sistema.Service;
using System.Text.Encodings.Web;

namespace Sistema.Middleware
{
    public class JwtAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly TokenService _tokenService;

        public JwtAuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            TokenService tokenService) : base(options, logger, encoder)
        {
            _tokenService = tokenService;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var header = Request.Headers.Authorization.ToString();

            if (!header.StartsWith("Bearer "))
                return Task.FromResult(AuthenticateResult.NoResult());

            var token = header[7..];
            var principal = _tokenService.Validar(token);

            if (principal == null)
                return Task.FromResult(AuthenticateResult.Fail("Token inválido"));

            var ticket = new AuthenticationTicket(principal, "jwt");
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}