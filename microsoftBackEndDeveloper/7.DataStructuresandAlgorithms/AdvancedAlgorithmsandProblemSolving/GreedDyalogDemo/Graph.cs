using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microsoftBackEndDeveloper.DataStructuresandAlgorithms.AdvancedAlgorithmsandProblemSolving
{
    // Classe que representa um grafo com arestas ponderadas (com peso)
    // Implementa o algoritmo de Dijkstra para encontrar o caminho mais curto
    public class Graph
    {
        // Dicionário que armazena o grafo:
        // Chave: nome do nó
        // Valor: dicionário com os vizinhos e seus pesos (distâncias)
        private Dictionary<string, Dictionary<string, int>> _graph;

        // Construtor que inicializa o grafo como um dicionário vazio
        public Graph()
        {
            _graph = new Dictionary<string, Dictionary<string, int>>();    
        }

        // Método para adicionar uma aresta entre dois nós
        // from: nó de origem
        // to: nó de destino
        // weight: peso (distância) da aresta
        public void AddEdge(string from, string to, int weight)
        {
            // Se o nó 'from' não existe, cria um novo entrada no dicionário
            if (!_graph.ContainsKey(from))
            {
                _graph[from] = new Dictionary<string, int>();
            }
            // Se o nó 'to' não existe, cria um novo entrada no dicionário
            if (!_graph.ContainsKey(to))
            {
                _graph[to] = new Dictionary<string, int>();
            }

            // Adiciona a aresta em ambas as direções (grafo não direcionado)
            _graph[from][to] = weight;
            _graph[to][from] = weight; // Grafo não direcionado (simétrico)
        }
        
        // Algoritmo de Dijkstra: encontra o caminho mais curto de um nó inicial para todos os outros nós
        // start: nó inicial para calcular as distâncias
        // Retorna: dicionário com as distâncias mais curtas do nó inicial para cada outro nó
        public Dictionary<string, int> Dijkstra(string start)
        {
            // Inicializa todas as distâncias com infinito (int.MaxValue)
            var distances = _graph.Keys.ToDictionary(node => node, node => int.MaxValue);
            // Define a distância do nó inicial como 0
            distances[start] = 0;
            // Fila de prioridade (SortedSet) que mantém os nós ordenados pela distância
            var priorityQueue = new SortedSet<(int, string)>{(0,start)};

            // Processa enquanto há nós na fila de prioridade
            while (priorityQueue.Count > 0)
            {
                // Remove o nó com a menor distância da fila
                var (currentDistance, currentNode) = priorityQueue.First();
                priorityQueue.Remove(priorityQueue.First());

                // Verifica todos os vizinhos do nó atual
                foreach (var neighbor in _graph[currentNode])
                {
                    // Calcula a nova distância através do nó atual
                    int distance = currentDistance + neighbor.Value;
                    // Se encontrou um caminho mais curto para o vizinho
                    if (distance < distances[neighbor.Key])
                    {
                        // Remove a entrada anterior da fila de prioridade
                        priorityQueue.Remove((distances[neighbor.Key], neighbor.Key));
                        // Atualiza a distância para o vizinho
                        distances[neighbor.Key] = distance;
                        // Adiciona o vizinho com a nova distância na fila de prioridade
                        priorityQueue.Add((distance, neighbor.Key));
                    }
                } 
            }
            // Retorna o dicionário com as distâncias mais curtas
            return distances;
        }
    }
}