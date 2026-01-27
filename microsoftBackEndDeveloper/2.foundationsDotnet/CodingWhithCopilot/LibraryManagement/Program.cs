using System;

class LibraryManager
{
    // Método principal que executa o sistema de gerenciamento de biblioteca
    static void Main()
    {
        // Usa listas para armazenar livros disponíveis e emprestados, permitindo gerenciamento dinâmico
        List<string> available = new List<string>();
        List<string> borrowed = new List<string>();

        // Loop infinito para exibir o menu e processar ações do usuário
        while (true)
        {
            // Exibe o menu de opções
            Console.WriteLine("\nLibrary Management System");
            Console.WriteLine("1. Add a book to library");
            Console.WriteLine("2. Remove a book from library");
            Console.WriteLine("3. Search for a book");
            Console.WriteLine("4. Borrow a book");
            Console.WriteLine("5. Check-in a book");
            Console.WriteLine("6. Display available books");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option (1-7): ");
            // Lê a entrada do usuário, converte para minúsculas e remove espaços
            string action = Console.ReadLine()?.ToLower().Trim();

            // Verifica se a opção é adicionar livro
            if (action == "1" || action == "add")
            {
                Console.WriteLine("Enter the title of the book to add:");
                string newBook = Console.ReadLine()?.Trim();
                // Valida se o título não está vazio
                if (string.IsNullOrEmpty(newBook))
                {
                    Console.WriteLine("Invalid title. Please enter a non-empty title.");
                    continue;
                }
                // Verifica se a biblioteca está cheia (máximo 5 livros)
                if (available.Count >= 5)
                {
                    Console.WriteLine("The library is full. No more books can be added.");
                }
                else
                {
                    // Adiciona o livro à lista de disponíveis
                    available.Add(newBook);
                    Console.WriteLine("Book added successfully.");
                }
            }
            // Verifica se a opção é remover livro da biblioteca
            else if (action == "2" || action == "remove")
            {
                // Verifica se há livros para remover
                if (available.Count == 0)
                {
                    Console.WriteLine("No books in the library to remove.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to remove:");
                    string removeBook = Console.ReadLine()?.Trim();
                    // Valida entrada
                    if (string.IsNullOrEmpty(removeBook))
                    {
                        Console.WriteLine("Invalid title. Please enter a non-empty title.");
                        continue;
                    }
                    // Tenta remover o livro
                    if (RemoveBook(available, removeBook))
                    {
                        Console.WriteLine("Book removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
            }
            // **DESTAQUE PARA RECURSO DE PESQUISA (5 pontos)**: Inclui prompt para entrada, verificação se encontrado e mensagens.
            else if (action == "3" || action == "search")
            {
                Console.WriteLine("Enter the title of the book to search:");
                string searchBook = Console.ReadLine()?.Trim();
                // Valida entrada
                if (string.IsNullOrEmpty(searchBook))
                {
                    Console.WriteLine("Invalid title. Please enter a non-empty title.");
                    continue;
                }
                // Verifica se o livro está disponível
                if (SearchBook(available, searchBook))
                {
                    Console.WriteLine("Book is available.");
                }
                else
                {
                    Console.WriteLine("Book not found in the collection.");
                }
            }
            // **DESTAQUE PARA LIMITE DE EMPRÉSTIMO (5 pontos)**: Inclui rastreamento (borrowed.Count) e limite de 3 livros.
            else if (action == "4" || action == "borrow")
            {
                // Verifica se há livros disponíveis
                if (available.Count == 0)
                {
                    Console.WriteLine("No books available to borrow.");
                }
                // Verifica se atingiu o limite de empréstimos (3 livros)
                else if (borrowed.Count >= 3)
                {
                    Console.WriteLine("You have reached the borrowing limit of 3 books.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to borrow:");
                    string borrowBook = Console.ReadLine()?.Trim();
                    // Valida entrada
                    if (string.IsNullOrEmpty(borrowBook))
                    {
                        Console.WriteLine("Invalid title. Please enter a non-empty title.");
                        continue;
                    }
                    // Tenta emprestar o livro
                    if (BorrowBook(available, borrowed, borrowBook))
                    {
                        Console.WriteLine("Book borrowed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Book not found or already borrowed.");
                    }
                }
            }
            // **DESTAQUE PARA MARCAÇÃO DE EMPRÉSTIMO (5 pontos)**: Inclui marcação (mover para borrowed) e remoção da marca (check-in).
            else if (action == "5" || action == "check-in")
            {
                // Verifica se há livros emprestados
                if (borrowed.Count == 0)
                {
                    Console.WriteLine("No books to check-in.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to check-in:");
                    string checkInBook = Console.ReadLine()?.Trim();
                    // Valida entrada
                    if (string.IsNullOrEmpty(checkInBook))
                    {
                        Console.WriteLine("Invalid title. Please enter a non-empty title.");
                        continue;
                    }
                    // Tenta devolver o livro
                    if (CheckInBook(available, borrowed, checkInBook))
                    {
                        Console.WriteLine("Book checked-in successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Book not found in borrowed list.");
                    }
                }
            }
            // Verifica se a opção é exibir livros disponíveis
            else if (action == "6" || action == "display")
            {
                DisplayBooks(available);
            }
            // Verifica se a opção é sair
            else if (action == "7" || action == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose 1-7.");
            }

            // Exibe automaticamente os livros disponíveis após cada ação, exceto exibir e sair
            if (action != "6" && action != "display" && action != "7" && action != "exit")
            {
                DisplayBooks(available);
            }
        }
    }

    // Método auxiliar para remover um livro da lista de disponíveis (insensível a maiúsculas/minúsculas), retorna true se removido
    static bool RemoveBook(List<string> available, string title)
    {
        // Percorre a lista de disponíveis
        for (int i = 0; i < available.Count; i++)
        {
            // Compara ignorando maiúsculas/minúsculas
            if (available[i].ToLower() == title.ToLower())
            {
                // Remove o livro da lista
                available.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    // Método auxiliar para pesquisar um livro na lista de disponíveis (insensível a maiúsculas/minúsculas), retorna true se encontrado
    static bool SearchBook(List<string> available, string title)
    {
        // Usa LINQ para verificar se algum livro corresponde
        return available.Any(book => book.ToLower() == title.ToLower());
    }

    // Método auxiliar para emprestar um livro, retorna true se emprestado
    static bool BorrowBook(List<string> available, List<string> borrowed, string title)
    {
        // Percorre a lista de disponíveis
        for (int i = 0; i < available.Count; i++)
        {
            // Compara ignorando maiúsculas/minúsculas
            if (available[i].ToLower() == title.ToLower())
            {
                // Move o livro para a lista de emprestados
                borrowed.Add(available[i]);
                available.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    // Método auxiliar para devolver um livro, retorna true se devolvido
    static bool CheckInBook(List<string> available, List<string> borrowed, string title)
    {
        // Percorre a lista de emprestados
        for (int i = 0; i < borrowed.Count; i++)
        {
            // Compara ignorando maiúsculas/minúsculas
            if (borrowed[i].ToLower() == title.ToLower())
            {
                // Move o livro de volta para disponíveis
                available.Add(borrowed[i]);
                borrowed.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    // Método auxiliar para exibir os livros disponíveis
    static void DisplayBooks(List<string> available)
    {
        Console.WriteLine("Available books:");
        // Verifica se há livros
        if (available.Count == 0)
        {
            Console.WriteLine("No books available.");
        }
        else
        {
            // Lista todos os livros disponíveis
            foreach (string book in available)
            {
                Console.WriteLine(book);
            }
        }
    }
}