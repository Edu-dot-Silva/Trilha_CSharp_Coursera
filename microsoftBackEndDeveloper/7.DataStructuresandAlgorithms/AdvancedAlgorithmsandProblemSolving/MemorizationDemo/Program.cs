using System;
using System.Collections.Generic;

// Demonstração de Memoização (Programação Dinâmica)
// Memoização é uma técnica de otimização que armazena resultados de subproblemas
// para evitar recalcular os mesmos valores várias vezes
class Program
{
    // // Dicionário que funciona como cache/memória para armazenar valores de Fibonacci já calculados
    // // Chave: número n
    // // Valor: resultado de Fibonacci(n)
    // static Dictionary<int, long> memoizationCache = new Dictionary<int, long>();

    // // Função que calcula o n-ésimo número de Fibonacci usando memoização
    // // Evita cálculos redundantes ao verificar se o valor já foi calculado
    // static long Fibonacci(int n)
    // {
    //     // Caso base: Fibonacci(0) = 0 e Fibonacci(1) = 1
    //     if (n <= 1)
    //         return n;

    //     // Verifica se o valor já foi calculado e está no cache
    //     if (memoizationCache.ContainsKey(n))
    //         // Retorna o valor já calculado, evitando recálculo
    //         return memoizationCache[n];

    //     // Se não estava no cache, calcula recursivamente
    //     // Fib(n) = Fib(n-1) + Fib(n-2)
    //     long result = Fibonacci(n - 1) + Fibonacci(n - 2);
    //     // Armazena o resultado no cache para futuras consultas
    //     memoizationCache[n] = result;

    //     // Retorna o resultado calculado e armazenado
    //     return result;
    // }

    // // Método principal que demonstra a eficiência da memoização
    // static void Main(string[] args)
    // {
    //     // Calcula o 50º número de Fibonacci rapidamente usando memoização
    //     // Sem memoização, isso levaria muito tempo devido às chamadas recursivas duplicadas
    //     Console.WriteLine("Fibonacci of 50: " + Fibonacci(50));
    // }

    // Dicionário que armazena dados em cache para evitar requisições repetidas
    // Chave: string da query (identificador da consulta)
    // Valor: resultado dos dados já buscados
    static Dictionary<string, string> cache = new Dictionary<string, string>();

    // Função que busca dados (simula uma requisição API) com cache/memoização
    // Se a query já foi buscada antes, retorna do cache (rápido)
    // Se não foi buscada, faz a busca (lento) e armazena no cache
    static string FetchData(string query){
        // Verifica se a query já está no cache
        if (cache.ContainsKey(query))
        {
            // Se está no cache, exibe mensagem de acerto e retorna o valor armazenado
            Console.WriteLine("Cache hit for query: " + query);
            return cache[query];
        }

        // Se não está no cache, simula uma requisição lenta à API
        Console.WriteLine("Fetching data from API for: " + query);
        // Delay de 2 segundos para simular latência de rede
        Thread.Sleep(2000); 
        // Cria o resultado dos dados
        string result = "Data for " + query;
        // Armazena o resultado no cache para futuras requisições
        cache[query] = result;
        // Retorna o resultado
        return result;
    }

    // Método principal que demonstra a eficiência do caching
    static void Main(string[] args)
    {
        // Primeira chamada com "user:123" - faz busca na API (2 segundos)
        Console.WriteLine(FetchData("user:123"));
        // Segunda chamada com "user:123" - retorna do cache (instantâneo)
        Console.WriteLine(FetchData("user:123"));
        // Chamada com "product:456" - novo dado, faz busca na API (2 segundos)
        Console.WriteLine(FetchData("product:456"));
    }
}