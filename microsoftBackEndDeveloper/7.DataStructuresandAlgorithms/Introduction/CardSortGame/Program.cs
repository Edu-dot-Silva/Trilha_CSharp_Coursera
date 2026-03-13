// Classe principal do programa contendo o ponto de entrada
class Program{
    static void Main()
    {
        //Chama o método que demonstra uma lista básica (não usado atualmente)
        //BasicListMethod();
        //Chama o método que demonstra o uso de LinkedList
        LinkedListMethod();
    }

    // Método que mostra um array simples de strings representando um baralho
    static void BasicListMethod()
    {
        string[] cardDeck =
        {
            "Ace of Spades",
            "King of Hearts",
            "Queen of Diamonds",
            "Jack of Clubs",
        };

        // Exibe o baralho original no console
        Console.WriteLine("Card Deck:");
        foreach (string card in cardDeck)
        {
            Console.WriteLine(card);
        }
    }

    // Método que demonstra o uso de LinkedList para gerenciar cartas
    static void LinkedListMethod()
    {
        // Declara uma linked list para armazenar cartas ordenadas
        LinkedList<string> sortedCards = new LinkedList<string>();

        // Adiciona cartas ao final da linked list
        sortedCards.AddLast("Ace of Spades");
        sortedCards.AddLast("King of Hearts");
        sortedCards.AddLast("Queen of Diamonds");
        sortedCards.AddLast("Jack of Clubs");

        // Exibe as cartas atualmente na lista
        Console.WriteLine("Sorted Cards:");
        foreach (string card in sortedCards)
        {
            Console.WriteLine(card);
        }

        // Remove uma carta específica da lista
        sortedCards.Remove("Queen of Diamonds");

        // Exibe as cartas após a remoção
        Console.WriteLine("\nSorted Cards after removal:");  
        foreach (string card in sortedCards)
        {
            Console.WriteLine(card);
        }
    }
}
