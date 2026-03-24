using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace Sistema.Service
{
    public static class VerificadorArgon2
    {
        // 1. GERAR HASH (Para o Cadastro)
        public static string GerarHash(string senha)
        {
            // Cria um SALT ALEATÓRIO para cada usuário (Segurança Máxima)
            var salt = new byte[16];
            RandomNumberGenerator.Fill(salt);



            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(senha))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 64 // 64 MB
            };

            var hash = argon2.GetBytes(32); // 32 bytes de hash é o ideal

            // FORMATO PHC: $argon2id$v=19$m=memoria,t=iterações,p=paralelismo$salt$hash
            // Isso permite que o sistema saiba como validar o hash no futuro
            return $"$argon2id$v=19$m={argon2.MemorySize},t={argon2.Iterations},p={argon2.DegreeOfParallelism}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
        }

        // 2. VALIDAR (Para o Login)
        public static bool Validar(string senhaDigitada, string hashDoBanco)
        {
            try
            {
                // Divide a string do banco para extrair as configurações e o salt
                var partes = hashDoBanco.Split('$');
                if (partes.Length < 6) return false;

                var config = partes[3].Split(',');
                var m = int.Parse(config[0].Split('=')[1]);
                var t = int.Parse(config[1].Split('=')[1]);
                var p = int.Parse(config[2].Split('=')[1]);
                var salt = Convert.FromBase64String(partes[4]);
                var hashOriginal = partes[5];

                var argon2 = new Argon2id(Encoding.UTF8.GetBytes(senhaDigitada))
                {
                    Salt = salt,
                    DegreeOfParallelism = p,
                    Iterations = t,
                    MemorySize = m
                };

                var novoHash = Convert.ToBase64String(argon2.GetBytes(32));
                return novoHash == hashOriginal;
            }
            catch
            {
                return false; // Se a string do banco estiver corrompida
            }
        }
    }
}
