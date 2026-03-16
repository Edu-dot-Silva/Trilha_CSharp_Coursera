using System;
using System.Threading.Tasks;

// Este programa demonstra conceitos de programação assíncrona em C#,
// incluindo tarefas assíncronas, delays simulados e tratamento de erros.

class Program
{
    // Exemplo básico de método Main assíncrono que inicia uma tarefa e aguarda sua conclusão.
    // static async Task Main(string[] args)
    // {
    //     Console.WriteLine("Starting the Task...");
    //     await PerformTaskAsync();
    //     Console.WriteLine("Task Completed.");
    // }

    // Método assíncrono que simula uma tarefa com delay de 3 segundos.
    // static async Task PerformTaskAsync()
    // {
    //     Console.WriteLine("Processing...");
    //     await Task.Delay(3000); // Simulates a 3-second delay
    //     Console.WriteLine("Task Finished.");
    // }

    // Método assíncrono que simula a busca de dados de uma API com delay de 2 segundos.
    // static async Task FetchDataAsync()
    // {
    //     Console.WriteLine("Fetching data from API...");
    //     await Task.Delay(2000); // Simulates a 2-second delay for fetching data
    //     Console.WriteLine("Data retrieved successfully.");
    // }

    // Exemplo de execução assíncrona paralela: inicia busca de dados em background enquanto lê entrada do usuário.
    // static async Task Main(string[] args)
    // {
    //     Console.WriteLine("Starting application");
    //     Task fetchDataTask = FetchDataAsync();

    //     Console.WriteLine("Enter your name: ");
    //     string name = Console.ReadLine();
    //     Console.WriteLine($"Hello, {name}!");

    //     await fetchDataTask; // Wait for the data fetching to complete
    // }

    // Método assíncrono que retorna uma string após um delay de 1.5 segundos.
    // static async Task<string> GetMessageAsync()
    // {
    //     await Task.Delay(1500); // Simulates a delay
    //     return "Hello from the async world!";
    // }

    // Exemplo de uso de ContinueWith para continuar após a conclusão de uma tarefa assíncrona.
    // static async Task Main(string[] args)
    // {
    //     Console.WriteLine("Fetching message...");
    //     Task<string> messageTask = GetMessageAsync();
    //     messageTask.ContinueWith(task =>
    //     {
    //         Console.WriteLine("Message received:");
    //         Console.WriteLine(task.Result);
    //     });

    //     Console.WriteLine("Doing other work...");
    //     await messageTask; // Wait for the message to be fetched before exiting
    // }

    // Método assíncrono que simula busca de dados com tratamento de erro: lança uma exceção após delay.
    static async Task FetchDataWIthErrorAsync()
    {
        try
        {
            Console.WriteLine("Fetching data...");
            await Task.Delay(2000); // Simula um delay de 2 segundos para buscar dados
            throw new Exception("Network failure"); // Simula uma falha de rede
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // Captura e exibe o erro
        }
    }

    // Método Main ativo que demonstra chamada assíncrona com tratamento de erro.
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting API Request..."); // Inicia a solicitação da API
        await FetchDataWIthErrorAsync(); // Chama o método assíncrono que pode lançar erro
        Console.WriteLine("Execution continued after handling error."); // Continua execução após tratamento do erro
    }
}