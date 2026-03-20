
// Classe que contém métodos de busca
public class Search
{
    // Método que realiza a busca linear em um array de inteiros
    // Recebe um array e um valor alvo, e retorna o índice do alvo se encontrado, ou -1 se não encontrado
    public static int LinearSearch(int[] arr, int target)
    {
        // Percorre o array do início ao fim
        for (int i = 0; i < arr.Length; i++)
        {
            // Verifica se o elemento atual é igual ao alvo
            if (arr[i] == target)
            {
                return i; // Retorna o índice do alvo
            }
        }
        return -1; // Retorna -1 se o alvo não for encontrado
    }
}
