using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinarySearchApp
{
    public class Search
    {
        // Método que realiza a busca binária em um array de inteiros ordenado
        // Recebe um array ordenado e um valor alvo, e retorna o índice do alvo se encontrado, ou -1 se não encontrado
        // A busca binária divide o array ao meio a cada iteração, tornando-a mais eficiente que a busca linear
        public static int BinarySearch(int[] arr, int target)
        {
            // Inicializa o ponteiro esquerdo no início do array
            int left = 0;
            // Inicializa o ponteiro direito no final do array
            int right = arr.Length - 1;

            // Continua a busca enquanto o ponteiro esquerdo não ultrapassar o direito
            while (left <= right)
            {
                // Calcula o índice do meio do intervalo atual
                int mid = left + (right - left) / 2;

                // Verifica se o elemento do meio é igual ao alvo
                if (arr[mid] == target)
                {
                    return mid; // Retorna o índice do alvo
                }
                // Se o elemento do meio é menor que o alvo, descarta a metade esquerda
                else if (arr[mid] < target)
                {
                    left = mid + 1; // Move a busca para a metade direita
                }
                // Se o elemento do meio é maior que o alvo, descarta a metade direita
                else
                {
                    right = mid - 1; // Move a busca para a metade esquerda
                }
            }
            return -1; // Retorna -1 se o alvo não for encontrado
        }
    }
}