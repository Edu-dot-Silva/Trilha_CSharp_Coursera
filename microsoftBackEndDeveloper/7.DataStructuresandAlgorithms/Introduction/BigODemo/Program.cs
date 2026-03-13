// Programa que ilustra tempos de execução (Big O) para várias operações
class Program
{
    static void Main()
    {
        // Demonstra acesso direto em array (O(1))
        DemonstrateArrayAccess();
        // Demonstra percurso em lista ligada (O(n))
        DemonstranteLinkedListTraversal();
        // Demonstra operações de pilha (O(1))
        DemonstrateStackOperations();
        // Demonstra operações de fila (O(1))
        DemonstrateQueueOperations();
    }

    // Acesso direto a um elemento de array, mostrando Complexidade O(1)
    static void DemonstrateArrayAccess()
    {
        Console.WriteLine("Array Access (O(1)):");
        int[] numbers = { 1, 2, 3, 4, 5 };
        Console.WriteLine(numbers[2]); // Acesso direto ao elemento (O(1))
        Console.WriteLine();
    }

    // Percurso de uma lista ligada, complexidade O(n) para varrer todos os elementos
    static void DemonstranteLinkedListTraversal()
    {
        Console.WriteLine("Linked List Traversal (O(n)):");
        LinkedList<int> linkedList = new LinkedList<int>[] { 1, 2, 3, 4, 5 };

        // Percorre a linked list para encontrar um elemento (O(n))
        foreach (int number in linkedList)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();
    }

    // Operações de pilha (push e pop) com tempo constante O(1)
    static void DemonstrateStackOperations()
    {
        Console.WriteLine("Stack Operations (O(1)) Push/Pop:");
        Stack<int> stack = new Stack<int>();
        stack.Push(10); // Adiciona um elemento (O(1))
        stack.Push(20);
        Console.WriteLine(stack.Pop()); // Remove o elemento do topo (O(1))
        Console.WriteLine();
    }

    // Operações de fila (enqueue e dequeue) com tempo constante O(1)
    static void DemonstrateQueueOperations()
    {
        Console.WriteLine("Queue Operations (O(1)) Enqueue/Dequeue:");
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(10); // Adiciona um elemento (O(1))
        queue.Enqueue(20);
        Console.WriteLine(queue.Dequeue()); // Remove o elemento da frente (O(1))
        Console.WriteLine();
    }
}