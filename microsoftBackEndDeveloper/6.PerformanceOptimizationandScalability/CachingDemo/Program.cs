using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

//NECESSARIO CORRIGIR

class Program
{
    static void Main()
    {
        // Inicializa um cache em memória com limite de tamanho de 1024 bytes
        IMemoryCache cache = new MemoryCache(new MemoryCacheOptions { SizeLimit = 1024 });

        // Define uma chave para armazenar os perfis de usuário no cache
        string key = "UserProfiles";

        // Loop que itera 3 vezes para demonstrar cache hit/miss
        for (int x = 0; x < 3; x++)
        {
            // Tenta recuperar dados do cache usando a chave
            // Se não existir, out users receberá null
            if (!cache.TryGetValue(key, out List<string>? users))
            {
                Console.WriteLine("\n--- CACHE MISS ---");
                Console.WriteLine("Cache miss. Fetching user profiles...\n");

                // Busca os perfis do usuário (simula busca de banco de dados)
                users = FetchUserProfiles();

                // Armazena os dados no cache com opções de expiração
                cache.Set(key, users, new MemoryCacheEntryOptions
                {
                    // Define expiração de 5 minutos a partir de agora
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    // Define o tamanho do item no cache
                    Size = 1
                });

                Console.WriteLine("User profiles cached.\n");
            }
            else
            {
                // Se os dados já estão em cache, exibe mensagem de sucesso
                Console.WriteLine("\n--- CACHE HIT ---");
                Console.WriteLine("Cache hit. Retrieved from cache.\n");
            }

            // Exibe os dados armazenados em cache
            Console.WriteLine($"Cached Data: {string.Join(", ", users)}\n");

            // Verifica se o cache foi limpo
            if (!cache.TryGetValue(key, out _))
            {
                Console.WriteLine("Cache successfully cleared");
            }
            else
            {
                Console.WriteLine("Cache still exists.");
            }

            // Aguarda 3 segundos antes da próxima iteração
            Console.WriteLine("\nAguardando 3 segundos...\n");
            System.Threading.Thread.Sleep(3000);
        }

        Console.WriteLine("\n=== FIM DA DEMONSTRAÇÃO ===");
        // Remove os dados do cache
        Console.WriteLine("Removing cached data...\n");
        cache.Remove(key);
    }

    static List<string> FetchUserProfiles()
    {
        // Retorna uma lista simulada de perfis de usuário
        return new List<string> { "Alice", "Bob", "Charlie" };
    }
}