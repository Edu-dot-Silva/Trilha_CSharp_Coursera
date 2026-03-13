using System.Diagnostics;

// Este programa demonstra três algoritmos de ordenação: Bubble Sort, Quick Sort e Merge Sort.
// Ele mede o tempo de execução de cada um para comparar sua eficiência.
// O array usado é pequeno para fins de demonstração, mas pode ser alterado para um maior.

class Program{
    static void Main(){
        // Array de números a ser ordenado
        int[] numbers = {5,3,8,4,2,7,1,6};

        // Código comentado para gerar um array maior e aleatório para testes de performance
        // Random rand = new Random();
        // int[] numbers = Enumerable.Range(1,1000000).OrderBy(x => rand.Next()).ToArray();

        // Código comentado para imprimir o array original
        // Console.WriteLine("Original Array");
        // Console.WriteLine(string.Join(",", numbers));

        // Inicia o cronômetro para medir o tempo do Bubble Sort
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Clona o array e ordena usando Bubble Sort
        int[] bubbleSortedArray = (int[])numbers.Clone();
        BubbleSort(bubbleSortedArray);
        stopwatch.Stop();
        Console.WriteLine("Bubble Sort Time: " + stopwatch.ElapsedMilliseconds + " ms");

        // Reinicia o cronômetro para Quick Sort
        stopwatch.Restart();
        int[] quickSortedArray = (int[])numbers.Clone();
        QuickSort(quickSortedArray, 0, quickSortedArray.Length - 1);
        stopwatch.Stop();
        Console.WriteLine("Quick Sort Time: " + stopwatch.ElapsedMilliseconds + " ms");

        // Reinicia o cronômetro para Merge Sort
        stopwatch.Restart();
        int[] mergeSortedArray = (int[])numbers.Clone();
        MergeSort(mergeSortedArray, 0, mergeSortedArray.Length - 1);
        stopwatch.Stop();
        Console.WriteLine("Merge Sort Time: " + stopwatch.ElapsedMilliseconds + " ms");    

        
    }

    // Implementação do algoritmo Bubble Sort
    // Este algoritmo compara elementos adjacentes e os troca se estiverem na ordem errada
    // Repete o processo até que nenhum troca seja necessária, indicando que o array está ordenado
    static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                }
            }
        }
    }

    // Implementação do algoritmo Quick Sort
    // Este é um algoritmo de divisão e conquista que escolhe um pivô e particiona o array
    // em elementos menores e maiores que o pivô, recursivamente ordenando as partições
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    // Função auxiliar para Quick Sort que particiona o array em torno de um pivô
    // O pivô é o último elemento; elementos menores ficam à esquerda, maiores à direita
    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
        (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
        return i + 1;
    }

    // Implementação do algoritmo Merge Sort
    // Este é um algoritmo de divisão e conquista que divide o array em metades,
    // ordena recursivamente cada metade e depois mescla as metades ordenadas
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    // Função auxiliar para Merge Sort que mescla duas subarrays ordenadas em uma única array ordenada
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int[] leftArr = arr[left..(mid + 1)];
        int[] rightArr = arr[(mid + 1)..(right + 1)];

        int i = 0, j = 0, k = left;

        while (i < leftArr.Length && j < rightArr.Length)
        {
            if (leftArr[i] <= rightArr[j])
            {
                arr[k++] = leftArr[i++];
            }
            else
            {
                arr[k++] = rightArr[j++];
            }
        }

        while (i < leftArr.Length)
        {
            arr[k++] = leftArr[i++];
        }

        while (j < rightArr.Length)
        {
            arr[k++] = rightArr[j++];
        }
    }
}