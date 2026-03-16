using System;

// Classe principal do programa de demonstração da árvore binária de busca
class Program
{
    // Método principal de entrada do programa
    static void Main()
    {
        // Cria uma instância da árvore binária de busca
        BinarySearchTree bst = new BinarySearchTree();

        // Array de valores inteiros a serem inseridos na árvore
        int[] values = {50, 30, 20, 40, 70, 60, 80};

        // Loop para inserir cada valor do array na árvore
        foreach (int value in values)
        {
            bst.Insert(value);
        }

        // Imprime o cabeçalho para o percurso em pré-ordem
        Console.WriteLine("Preorder Traversal:");
        // Executa e imprime o percurso em pré-ordem (raiz, esquerda, direita)
        bst.PreorderTraversal();

        // Imprime o cabeçalho para o percurso em ordem
        Console.WriteLine("\nInorder Traversal:");
        // Executa e imprime o percurso em ordem (esquerda, raiz, direita)
        bst.InorderTraversal(bst.Root);

        // Imprime o cabeçalho para o percurso em pós-ordem
        Console.WriteLine("\nPostorder Traversal:");
        // Executa e imprime o percurso em pós-ordem (esquerda, direita, raiz)
        bst.PostorderTraversal(bst.Root);

        // Imprime o cabeçalho para o percurso em nível
        Console.WriteLine("\nLevel Order Traversal:");
        // Executa e imprime o percurso em nível (largura)
        bst.LevelOrderTraversal();
    }
}