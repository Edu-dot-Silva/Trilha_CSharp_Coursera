// Programa demonstrando as estruturas Stack e Queue
class Program
{
    static void Main()
    {
        // Método que mostra operações de pilha (LIFO)
        //PopAndPush();
        // Método que mostra operações de fila (FIFO)
        EnqueueAndDequeue();
    }

    // Demonstra uso de uma pilha (Stack) para operações de desfazer
    static void PopAndPush()
    {
        Stack<string> actionStack = new Stack<string>();

        // Empilha ações conforme são realizadas
        actionStack.Push("Typed 'Hello'");
        actionStack.Push("Typed 'World'");
        actionStack.Push("Deleted 'World'");

        // Remove e mostra a última ação (desfazer)
        Console.WriteLine("Undoing last action: " + actionStack.Pop());
    }

    // Demonstra uso de uma fila (Queue) para gerenciamento de impressão
    static void EnqueueAndDequeue()
    {
        Queue<string> printQueue = new Queue<string>();

        // Adiciona documentos à fila de impressão
        printQueue.Enqueue("Document1.pdf");
        printQueue.Enqueue("Document2.pdf");
        printQueue.Enqueue("Document3.pdf");

        // Processa a fila enquanto houver itens
        while (printQueue.Count > 0)
        {
            // Retira e exibe o próximo documento a ser impresso
            Console.WriteLine("Printing: " + printQueue.Dequeue());
        }
    }
}