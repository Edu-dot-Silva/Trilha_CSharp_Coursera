using System.Collections;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

// Classe que representa uma tarefa com nome, prazo e recompensa
class Task
{
    // Nome da tarefa
    public string Name{get;}
    // Prazo (deadline) para conclusão da tarefa
    public int Deadline{get;}
    // Recompensa em pontos pela conclusão da tarefa
    public int Reward{get;}

    // Construtor que inicializa uma tarefa com seus atributos
    public Task(string name, int deadline, int reward)
    {
        Name = name;
        Deadline = deadline;
        Reward = reward;
    }
}

class Program
{
    // Algoritmo guloso (Greedy) para agendamento de tarefas
    // Objetivo: maximizar a recompensa total agendando tarefas respeitando seus prazos
    static List<Task> GreedyTaskScheduler(List<Task> tasks)
    {
        // Ordena as tarefas por recompensa em ordem decrescente (maior recompensa primeiro)
        tasks.Sort((a, b) => b.Reward.CompareTo(a.Reward));
        // Lista para armazenar as tarefas agendadas
        List<Task> schedule = new List<Task>();
        // Conjunto para rastrear quais slots de tempo já estão ocupados
        HashSet<int> timeSlots = new HashSet<int>();

        // Para cada tarefa (em ordem de recompensa)
        foreach (var task in tasks)
        {
            // Tenta encontrar um slot de tempo disponível antes do prazo
            // Começa do prazo e vai retrocedendo até o slot 1
            for (int slot = task.Deadline; slot > 0; slot--)
            {
                // Se o slot está disponível
                if (!timeSlots.Contains(slot))
                {
                    // Marca o slot como ocupado
                    timeSlots.Add(slot);
                    // Adiciona a tarefa ao cronograma
                    schedule.Add(task);
                    // Passa para a próxima tarefa
                    break;
                }
            }
        }

        // Retorna a lista de tarefas agendadas
        return schedule;
    }

    // Método principal que demonstra o algoritmo de Dijkstra
    static void Main(string[] args)
    {
        // Exemplo de agendamento de tarefas (comentado)
        // List<Task> tasks = new List<Task>
        // {
        //     new Task("Task A", 2, 100),
        //     new Task("Task B", 1, 50),
        //     new Task("Task C", 2, 20),
        //     new Task("Task D", 1, 70),
        // };

        // List<Task> scheduledTasks = GreedyTaskScheduler(tasks);

        // foreach (var task in scheduledTasks)
        // {
        //     Console.WriteLine($"{task.Name} (Deadline: {task.Deadline}, Reward: {task.Reward})");
        // }

        // Cria um novo grafo para demonstrar o algoritmo de Dijkstra
        Graph graph = new Graph();
        // Adiciona arestas (conexões) entre nós do grafo com seus pesos
        graph.AddEdge("A", "B", 1);
        graph.AddEdge("A", "C", 4);
        graph.AddEdge("B", "C", 2);
        graph.AddEdge("B", "D", 5);
        graph.AddEdge("C", "D", 1);

        // Executa o algoritmo de Dijkstra começando do nó "A"
        // Retorna as distâncias mais curtas do nó A para todos os outros nós
        Dictionary<string, int> distances = graph.Dijkstra("A");
        // Exibe as distâncias calculadas
        foreach (var kvp in distances)        {
            Console.WriteLine($"Distance from A to {kvp.Key}: {kvp.Value}");
        }
    }
}