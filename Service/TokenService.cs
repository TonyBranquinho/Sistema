using System.Security.Cryptography;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Sistema.Service
{
    public class TokenService
    {
        private readonly string _secret;
        private readonly string _issuer;
        private readonly int _expiryMinutes;

        public TokenService(IConfiguration config)
        {
            _secret = config["Jwt:Secret"]!;
            _issuer = config["Jwt:Issuer"]!;
            _expiryMinutes = int.Parse(config["Jwt:ExpiryMinutes"]!);
        }




        public string Gerar(Modelos.Usuario usuario)
        {
            // JWT tem 3 partes: header.payload.assinatura
            // Cada parte é Base64Url — variação do Base64 segura para URLs (sem +, /, =)

            var header = Base64UrlEncode(JsonSerializer.SerializeToUtf8Bytes(new
            {
                alg = "HS256",  // algoritmo de assinatura
                typ = "JWT"
            }));

            var payload = Base64UrlEncode(JsonSerializer.SerializeToUtf8Bytes(new
            {
                sub = usuario.Id.ToString(),   // subject — identificador do usuário
                nome = usuario.Nome,
                email = usuario.Email,
                perm = usuario.NivelPermisao,
                ativo = usuario.Ativo,
                iss = _issuer,                 // issuer — quem emitiu o token
                iat = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),               // issued at
                exp = DateTimeOffset.UtcNow.AddMinutes(_expiryMinutes).ToUnixTimeSeconds() // expiry
            }));

            var assinatura = Assinar($"{header}.{payload}");

            return $"{header}.{payload}.{assinatura}";
        }




        public ClaimsPrincipal? Validar(string token)
        {
            var partes = token.Split('.');
            if (partes.Length != 3) return null;

            // PRIMEIRO valida a assinatura — nunca confie no payload antes disso.
            // Se alguém adulterou o token, a assinatura não bate.
            var assinaturaEsperada = Assinar($"{partes[0]}.{partes[1]}");
            var assinaturaRecebida = Encoding.UTF8.GetBytes(partes[2]);
            var assinaturaCorreta = Encoding.UTF8.GetBytes(assinaturaEsperada);

            if (!CryptographicOperations.FixedTimeEquals(assinaturaCorreta, assinaturaRecebida))
                return null;

            // Só depois de validar a assinatura, lê o payload
            var payloadJson = Base64UrlDecode(partes[1]);
            using var doc = JsonDocument.Parse(payloadJson);
            var root = doc.RootElement;

            // Valida expiração
            var exp = root.GetProperty("exp").GetInt64();
            if (DateTimeOffset.UtcNow.ToUnixTimeSeconds() > exp)
                return null;

            // Monta o ClaimsPrincipal — é isso que o ASP.NET usa como "usuário logado"
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, root.GetProperty("sub").GetString()!),
                new(ClaimTypes.Name,           root.GetProperty("nome").GetString()!),
                new(ClaimTypes.Email,          root.GetProperty("email").GetString()!)
            };

            var identidade = new ClaimsIdentity(claims, "jwt");
            return new ClaimsPrincipal(identidade);
        }

        // ── helpers de encoding ───────────────────────────────────────────

        private string Assinar(string input)
        {
            var chave = Encoding.UTF8.GetBytes(_secret);
            var dados = Encoding.UTF8.GetBytes(input);
            using var hmac = new HMACSHA256(chave);
            return Base64UrlEncode(hmac.ComputeHash(dados));
        }

        private static string Base64UrlEncode(byte[] dados) =>
            Convert.ToBase64String(dados)
                   .TrimEnd('=')
                   .Replace('+', '-')
                   .Replace('/', '_');

        private static byte[] Base64UrlDecode(string input)
        {
            var s = input.Replace('-', '+').Replace('_', '/');
            s += (s.Length % 4) switch { 2 => "==", 3 => "=", _ => "" };
            return Convert.FromBase64String(s);
        }
    }
}