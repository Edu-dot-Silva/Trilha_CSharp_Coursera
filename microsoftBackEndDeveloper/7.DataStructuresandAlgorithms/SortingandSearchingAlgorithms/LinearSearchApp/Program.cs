class Program
{
    static void Main()
    {
        // Cria um array de exemplo com números inteiros para demonstração
        int[] numbers = { 5, 3, 8, 1, 2 };
        // Define o valor alvo a ser buscado no array
        int target = 1;

        // Chama o método de busca linear e armazena o resultado (índice ou -1)
        int result = LinearSearch(numbers, target);

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