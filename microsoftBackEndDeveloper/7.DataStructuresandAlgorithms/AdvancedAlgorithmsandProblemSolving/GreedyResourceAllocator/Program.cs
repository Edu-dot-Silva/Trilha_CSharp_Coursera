using System;
using System.Collections.Generic;
using System.Linq;

// Programa que demonstra alocação gulosa de recursos em servidores
// Objetivo: alocar recursos de forma eficiente, maximizando o uso dos servidores
class Program
{
    // Método principal que inicia a demonstração
    static void Main()
    {
        // Lista de recursos a serem alocados (tamanhos dos recursos)
        List<int> resources = new List<int> { 10, 20, 30 };
        // Lista de capacidades dos servidores
        List<int> servers = new List<int> { 15, 25, 5 };

        Console.WriteLine("Alocação Inicial de Recursos:");
        // Chama o método de alocação
        AllocateResources(resources, servers);
    }

    // Método que implementa o algoritmo guloso otimizado para alocação de recursos
    // Ordena recursos e servidores em ordem decrescente para melhor eficiência
    // Usa abordagem "best fit" guloso: escolhe o servidor que deixa menos espaço restante
    static void AllocateResources(List<int> resources, List<int> servers)
    {
        // Ordena os recursos em ordem decrescente (maiores primeiro)
        // Isso ajuda a alocar recursos grandes primeiro, melhorando a eficiência
        resources.Sort((a, b) => b.CompareTo(a));

        // Cria uma lista de servidores com índices para rastreamento
        // Cada servidor é representado por uma tupla (índice, capacidade)
        var serverList = servers.Select((capacity, index) => (index, capacity)).ToList();
        // Ordena os servidores por capacidade em ordem decrescente
        serverList.Sort((a, b) => b.capacity.CompareTo(a.capacity));

        // Mantém as capacidades originais para exibição
        List<int> originalCapacities = new List<int>(servers);

        // Dicionário para armazenar a alocação: chave = índice do servidor, valor = lista de recursos alocados
        Dictionary<int, List<int>> allocation = new Dictionary<int, List<int>>();
        for (int i = 0; i < servers.Count; i++)
        {
            allocation[i] = new List<int>();
        }

        // Para cada recurso (já ordenado decrescentemente)
        foreach (var resource in resources)
        {
            // Variável para rastrear a melhor escolha de servidor
            int bestServerIndex = -1;
            int minRemainingCapacity = int.MaxValue;

            // Procura o servidor que pode acomodar o recurso e deixa a menor capacidade restante
            // Isso é uma abordagem "best fit" gulosa para melhor balanceamento
            for (int i = 0; i < serverList.Count; i++)
            {
                var (serverIndex, currentCapacity) = serverList[i];
                if (currentCapacity >= resource)
                {
                    int remainingCapacity = currentCapacity - resource;
                    if (remainingCapacity < minRemainingCapacity)
                    {
                        minRemainingCapacity = remainingCapacity;
                        bestServerIndex = serverIndex;
                    }
                }
            }

            // Se encontrou um servidor adequado, aloca o recurso
            if (bestServerIndex != -1)
            {
                allocation[bestServerIndex].Add(resource);
                // Atualiza a capacidade do servidor na lista ordenada
                for (int i = 0; i < serverList.Count; i++)
                {
                    if (serverList[i].index == bestServerIndex)
                    {
                        serverList[i] = (bestServerIndex, serverList[i].capacity - resource);
                        break;
                    }
                }
            }
            // Se nenhum servidor pode acomodar, o recurso é ignorado (não alocado)
        }

        // Exibe os resultados da alocação
        for (int i = 0; i < servers.Count; i++)
        {
            // Calcula a capacidade restante atual
            int remaining = originalCapacities[i] - allocation[i].Sum();
            Console.WriteLine($"Servidor {i + 1} (Capacidade Original: {originalCapacities[i]}): Recursos Alocados: {string.Join(", ", allocation[i])}, Capacidade Restante: {remaining}");
        }
    }
}