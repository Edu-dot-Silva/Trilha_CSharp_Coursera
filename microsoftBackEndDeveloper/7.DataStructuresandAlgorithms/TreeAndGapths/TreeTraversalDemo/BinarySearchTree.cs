using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TreeTraversalDemo
{
    // Classe que representa um nó da árvore binária de busca
    class Node
    {
        // Valor inteiro armazenado no nó
        public int Data;
        // Referência para o nó filho à esquerda
        public Node Left;
        // Referência para o nó filho à direita
        public Node Right;

        // Construtor do nó, inicializa com o valor fornecido
        public Node(int data)
        {
            Data = data;
            Left = Right = null;
        }
    }

    // Classe que implementa uma árvore binária de busca
    public class BinarySearchTree
    {
        // Raiz da árvore
        public Node Root;

        // Método público para inserir um valor na árvore
        public void Insert(int data)
        {
            Root = InsertRec(Root, data);
        }

        // Método recursivo auxiliar para inserir um valor na árvore
        private Node InsertRec(Node root, int data)
        {
            // Se o nó raiz é nulo, cria um novo nó
            if (root == null)
                return new Node(data);

            // Se o valor é menor que o valor do nó atual, insere na subárvore esquerda
            if (data < root.Data)
                root.Left = InsertRec(root.Left, data);
            // Se o valor é maior, insere na subárvore direita
            else if (data > root.Data)
                root.Right = InsertRec(root.Right, data);

            // Retorna o nó raiz (inalterado se o valor já existir)
            return root;
        }

        // Método para percorrer a árvore em pré-ordem (raiz, esquerda, direita)
        public void PreorderTraversal(Node node)
        {
            // Se o nó é nulo, retorna
            if (node == null)
                return;

            // Imprime o valor do nó atual
            Console.Write(node.Data + " ");
            // Percorre a subárvore esquerda
            PreorderTraversal(node.Left);
            // Percorre a subárvore direita
            PreorderTraversal(node.Right);
        }

        // Método para percorrer a árvore em ordem (esquerda, raiz, direita)
        public void InorderTraversal(Node node)
        {
            // Se o nó é nulo, retorna
            if (node == null)
                return;

            // Percorre a subárvore esquerda
            InorderTraversal(node.Left);
            // Imprime o valor do nó atual
            Console.Write(node.Data + " ");
            // Percorre a subárvore direita
            InorderTraversal(node.Right);
        }

        // Método para percorrer a árvore em pós-ordem (esquerda, direita, raiz)
        public void PostorderTraversal(Node node)
        {
            // Se o nó é nulo, retorna
            if (node == null)
                return;

            // Percorre a subárvore esquerda
            PostorderTraversal(node.Left);
            // Percorre a subárvore direita
            PostorderTraversal(node.Right);
            // Imprime o valor do nó atual
            Console.Write(node.Data + " ");
        }

        // Método para percorrer a árvore em nível (usando fila)
        public void LevelOrderTraversal()
        {
            // Se a raiz é nula, retorna
            if (Root == null)
                return;

            // Cria uma fila para armazenar os nós
            Queue<Node> queue = new Queue<Node>();
            // Adiciona a raiz à fila
            queue.Enqueue(Root);

            // Enquanto houver nós na fila
            while (queue.Count > 0)
            {
                // Remove o nó da frente da fila
                Node current = queue.Dequeue();
                // Imprime o valor do nó atual
                Console.Write(current.Data + " ");

                // Se o nó tem filho esquerdo, adiciona à fila
                if (current.Left != null)
                    queue.Enqueue(current.Left);
                // Se o nó tem filho direito, adiciona à fila
                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }
        }

    }
}