using Konscious.Security.Cryptography;
using System.Text;

namespace Sistema.service
{
    public static class VerificadorArgon2
    {
        // Método para gerar o hash (usado no Cadastro)
        public static string GerarHash(string senha)
        {
            var salt = new byte[16]; // Em produção, use um salt aleatório e armazene-o
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(senha))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 64 // 64 MB
            };

            return Convert.ToBase64String(argon2.GetBytes(16));
        }

        // Método para validar (usado no Login)
        public static bool Validar(string senhaDigitada, string hashDoBanco)
        {
            var novoHash = GerarHash(senhaDigitada);
            return novoHash == hashDoBanco;
        }
    }

}
