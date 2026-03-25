using Konscious.Security.Cryptography;
using System.Security.Cryptography;

namespace Sistema.Service
{
    public class PasswordService
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 4;
        private const int Memory = 65536;
        private const int Threads = 2;

        public string Hashear(string senha)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Computar(senha, salt);

            // Salt e hash juntos em Base64, separados por "."
            // Assim ficam numa única coluna string no banco
            return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }

        public bool Verificar(string senha, string hashArmazenado)
        {
            var partes = hashArmazenado.Split('.');
            if (partes.Length != 2) return false;

            var salt = Convert.FromBase64String(partes[0]);
            var hashOriginal = Convert.FromBase64String(partes[1]);
            var hashNovo = Computar(senha, salt);

            return CryptographicOperations.FixedTimeEquals(hashNovo, hashOriginal);
        }

        private byte[] Computar(string senha, byte[] salt)
        {
            using var argon2 = new Argon2id(System.Text.Encoding.UTF8.GetBytes(senha))
            {
                Salt = salt,
                Iterations = Iterations,
                MemorySize = Memory,
                DegreeOfParallelism = Threads
            };
            return argon2.GetBytes(HashSize);
        }
    }
}