
class Program
{
    static void Main()
    {
        // Cria um array de números inteiros ordenados para demonstração
        int[] numbers = {10, 20, 30, 40, 50};
        // Define o valor alvo a ser buscado no array
        int target = 30;

        // Código comentado para gerar um array maior e escolher um alvo aleatório
        // int[] numbers = GenerateSortedUsersIds(100000);
        // Random random = new Random();
        // int target = numbers[random.Next(numbers.Length)];

        // Chama o método de busca binária e armazena o resultado (índice ou -1)
        int result = BinarySearch(numbers, target);

        // Verifica se o resultado indica que o elemento foi encontrado
        if (result != -1)
        {
            // Imprime mensagem informando que o elemento foi encontrado e seu índice
            Console.WriteLine($"Elemento {target} encontrado no índice {result}.");
        }
        else
        {
            // Imprime mensagem informando que o elemento não foi encontrado
            Console.WriteLine($"Elemento {target} não encontrado no array.");
        }
    }
}
