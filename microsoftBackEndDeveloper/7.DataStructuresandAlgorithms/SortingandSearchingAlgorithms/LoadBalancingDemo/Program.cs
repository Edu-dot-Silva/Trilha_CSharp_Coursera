// Este arquivo contém vários exemplos de algoritmos simples de balanceamento de carga.
// Cada bloco comentado é um exemplo independente (Round Robin, Least Connections, Weight Round Robin, IP Hash).
// Você pode descomentar um bloco de cada vez para executar apenas um exemplo.

// --------------------------------------------------------------------------------
// Exemplo 1: Round Robin
// --------------------------------------------------------------------------------
// Estratégia: distribui as requisições de forma circular entre os servidores.
// Cada nova requisição vai para o próximo servidor da lista, retornando ao começo ao atingir o fim.
// Vantagem: simples e previsível.
// Limitação: não considera a carga real dos servidores.

// class RoundRobinLB
// {
//     private List<string> servers;
//     private int index = 0;

//     // Constrói o balanceador com a lista de servidores disponíveis.
//     public RoundRobinLB(List<string> servers)
//     {
//         this.servers = servers;
//     }

//     // Retorna o próximo servidor usando índice circular.
//     public string GetServer()
//     {
//         string server = servers[index];
//         // Avança o índice; mod garante que volta ao início.
//         index = (index + 1) % servers.Count;
//         return server;  
//     }

//     // Programa de demonstração (descomente para executar).
//     class Program
//     {
//         static void Main()
//         {
//             var servers = new List<string> { "Server1", "Server2", "Server3" };
//             var lb = new RoundRobinLB(servers);

//             // Imprime qual servidor atende a cada requisição.
//             for (int i = 0; i < 10; i++)
//             {
//                 Console.WriteLine(lb.GetServer());
//             }
//         }
//     }
// }

// --------------------------------------------------------------------------------
// Exemplo 2: Menor Número de Conexões (Least Connections)
// --------------------------------------------------------------------------------
// Estratégia: direciona a requisição para o servidor com menos conexões ativas.
// Vantagem: tenta equilibrar de acordo com a carga atual.
// Limitação: precisa de um contador de conexões válido para cada servidor.

// class LeastConnectionsLB
// {
//     // Mapeia servidor -> número de conexões ativas.
//     private Dictionary<string, int> serverConnections;

//     // Inicializa o dicionário com contagem zerada para cada servidor.
//     public LeastConnectionsLB(List<string> servers)
//     {
//         serverConnections = servers.ToDictionary(s => s, s => 0);
//     }

//     // Função auxiliar para simular um cenário inicial com cargas diferentes.
//     public void SetInitialLoad()
//     {
//         // Configura valores fictícios de conexões para demonstrar o algoritmo.
//         string server = serverConnections.ElementAt(0).Key;
//         serverConnections[server] = 7;
//         server = serverConnections.ElementAt(1).Key;
//         serverConnections[server] = 9;
//         server = serverConnections.ElementAt(2).Key;
//         serverConnections[server] = 5;
//     }

//     // Retorna o servidor com menos conexões e incrementa sua contagem.
//     public string GetServer()
//     {
//         string server = serverConnections.OrderBy(kv => kv.Value).First().Key;
//         serverConnections[server]++;
//         return server;  
//     }

//     // Programa de demonstração (descomente para executar).
//     class Program
//     {
//         static void Main()
//         {
//             var servers = new List<string> { "Server1", "Server2", "Server3" };
//             var lb = new LeastConnectionsLB(servers);
//             lb.SetInitialLoad();

//             for (int i = 0; i < 10; i++)
//             {
//                 Console.WriteLine(lb.GetServer());
//             }
//         }
//     }
// }

// --------------------------------------------------------------------------------
// Exemplo 3: Round Robin com Pesos (Weight Round Robin)
// --------------------------------------------------------------------------------
// Estratégia: servidores recebem requisições proporcionalmente aos seus pesos.
// Aqui representamos pesos repetindo o identificador do servidor na lista interna.
// Vantagem: servidores mais potentes podem receber mais requisições.
// Limitação: funciona melhor quando os pesos são estáveis e conhecidos.

// class WeightRoundRobinLB
// {
//     private List<string> servers;
//     private int index = 0;

//     // Constrói a lista ponderada de servidores com base nos pesos fornecidos.
//     public WeightRoundRobinLB(Dictionary<string, int> serverWeights)
//     {
//         servers = new List<string>();
//         foreach (var kv in serverWeights)
//         {
//             // Adiciona o servidor N vezes, onde N é o peso.
//             for (int i = 0; i < kv.Value; i++)
//             {
//                 servers.Add(kv.Key);
//             }
//         }
//     }

//     // Retorna servidor baseado em índice circular na lista ponderada.
//     public string GetServer()
//     {
//         string server = servers[index];
//         index = (index + 1) % servers.Count;
//         return server;  
//     }

//     // Programa de demonstração (descomente para executar).
//     class Program
//     {
//         static void Main()
//         {
//             var serverWeights = new Dictionary<string, int>
//             {
//                 {"Server1", 2},
//                 {"Server2", 1},
//                 {"Server3", 3}
//             };
//             var lb = new WeightRoundRobinLB(serverWeights);

//             for (int i = 0; i < 10; i++)
//             {
//                 Console.WriteLine(lb.GetServer());
//             }
//         }
//     }
// }

// --------------------------------------------------------------------------------
// Exemplo 4: IP Hash (Consistent Hashing)
// --------------------------------------------------------------------------------
// Estratégia: usa um hash do IP do cliente para escolher o servidor.
// Isso garante que o mesmo cliente sempre vá para o mesmo servidor, enquanto o conjunto de servidores estiver estável.
// Vantagem: mantém afinidade (stickiness) sem necessidade de manter estado externo.
// Limitação: ao alterar a lista de servidores, muitos clientes mudam de servidor (não é true consistent hashing).

class IPHashLB
{
    private List<string> servers;

    public IPHashLB(List<string> servers)
    {
        this.servers = servers;
    }

    // Calcula um hash inteiro a partir do endereço IP (usando MD5 para exemplificação).
    private int GetHash(string ip)
    {
        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] hashBytes = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(ip));
            return BitConverter.ToInt32(hashBytes, 0);
        }
    }

    // Seleciona um servidor com base no hash do IP do cliente.
    public string GetServer(string clientIP)
    {
        int index = Math.Abs(GetHash(clientIP)) % servers.Count;
        return servers[index];
    }

    // Programa de demonstração (deixe descomentado para executar).
    class Program
    {
        static void Main()
        {
            var servers = new List<string> { "Server1", "Server2", "Server3" };
            var lb = new IPHashLB(servers);

            Console.WriteLine(lb.GetServer("192.168.1.1"));
            Console.WriteLine(lb.GetServer("192.168.1.2"));
        }
    }
}