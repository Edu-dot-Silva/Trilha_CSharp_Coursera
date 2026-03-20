using System.Diagnostics;

class Program{
    static int BinarySearch(int[] arr, int target)
    {
        if (sortedArray.Length == 0)
        {
            return -1; // Retorna -1 se o array estiver vazio
        }

        int left = 0; // Ponteiro para o início do array
        int right = sortedArray.Length - 1; // Ponteiro para o final do array

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // Calcula o índice do meio

            if (sortedArray[mid] == target)
            {
                return mid; // Retorna o índice do alvo se encontrado
            }
            else if (sortedArray[mid] < target)
            {
                left = mid + 1; // Move o ponteiro esquerdo para a direita
            }
            else
            {
                right = mid - 1; // Move o ponteiro direito para a esquerda
            }
        }
        return -1; // Retorna -1 se o alvo não for encontrado
    }

    static void Main()
    {
        int[] usersIds = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // Array de IDs de usuários ordenados
        int targetId = 5; // ID de usuário a ser buscado
        int result = BinarySearch(usersIds, targetId); // Chama o método de busca binária
        Console.WriteLine(result != -1
            ? $"ID {targetId} encontrado no índice {result}."
            : $"ID {targetId} não encontrado no array.");
    }

    // static void Main()
    // {
    //     int[] usersIds = GenerateSotedUsersIds(100000); // Gera um array de IDs de usuários ordenados
    //     Random random = new Random();
    //     int targetId = usersIds[random.Next(usersIds.Length)]; // Seleciona um ID de usuário aleatório do array

    //     int result = BinarySearch(usersIds, targetId); // Chama o método de busca binária
    //     Console.WriteLine(result != -1
    //         ? $"ID {targetId} encontrado no índice {result}."
    //         : $"ID {targetId} não encontrado no array.");
    // }

    static void Main()
    {
        int seachId = 5; // ID de usuário a ser buscado
        int[] usersIds = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // Array de IDs de usuários ordenados

        int[] usersIds = GenerateSotedUsersIds(100000); // Gera um array de IDs de usuários ordenados
        Random random = new Random();
        int targetId = usersIds[random.Next(usersIds.Length)]; // Seleciona um ID de usuário aleatório do array

        Stopwatch stopwatch = Stopwatch.StartNew(); // Inicia o cronômetro para medir o tempo de execução
        int index = BinarySearch(usersIds, seachId); // Chama o método de busca binária
        stopwatch.Stop(); // Para o cronômetro após a busca

        Console.WriteLine($"Binary search found item at index {index}");
        Console.WriteLine($"Binary Search Time: {stopwatch.ElapsedMilliseconds} ms"); // Imprime o tempo gasto para a busca

        stopwatch.Restart(); // Reinicia o cronômetro para medir o tempo da busca linear
        index = LinearSearch(usersIds, seachId); // Chama o método de busca linear
        stopwatch.Stop(); // Para o cronômetro após a busca linear
        Console.WriteLine($"Linear search found item at index {index}");
        Console.WriteLine($"Linear Search Time: {stopwatch.ElapsedMilliseconds} ms"); // Imprime o tempo gasto para a busca linear
    }

    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                return i; // Retorna o índice do alvo se encontrado
            }
        }
        return -1; // Retorna -1 se o alvo não for encontrado
    }
}