using Sistema.Service;

namespace Sistema.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        // RequestDelegate é o "próximo passo" no pipeline do ASP.NET.
        // Cada middleware recebe o contexto, faz seu trabalho, e chama _next.
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, TokenService tokenService)
        {
            // Tenta extrair o token do header Authorization: Bearer <token>
            var token = ExtrairDoHeader(context);

            if (token is not null)
            {
                var principal = tokenService.Validar(token);

                if (principal is not null)
                {
                    // Isso é o que faz context.User.Identity.IsAuthenticated == true
                    // em qualquer controller da aplicação
                    context.User = principal;
                }
            }

            await _next(context); // Passa para o próximo middleware
        }

        private static string? ExtrairDoHeader(HttpContext context)
        {
            var header = context.Request.Headers.Authorization.ToString();
            return header.StartsWith("Bearer ") ? header[7..] : null;
        }
    }
}