using System.Net.NetworkInformation;
using Newtonsoft.Json;

namespace JsonExample{
public class Person{
    public required string Name {get;set;}
    public int Age {get;set;}
    public double Height {get;set;}
}

public class Program {
    static void Main(string[] args){
        string jsonSting = @"{
        ""Name"" : ""Eduardo"",
        ""Age"" : 26,
        ""Height"" : 1.75
        }";

        Person person = JsonConvert.DeserializeObject<Person>(jsonSting);

            Console.WriteLine("Dados da pessoa:");
            Console.WriteLine($"Nome: {person.Name}");
            Console.WriteLine($"Idade: {person.Age}");
            Console.WriteLine($"Cidade: {person.Height}");

        Person novaPessoa = new Person{
            Name = "Maria",
            Age = 30,
            Height = 1.50
        };

        string pessoa2 = JsonConvert.SerializeObject(novaPessoa, Formatting.Indented);
    
        Console.WriteLine("Objeto Person serializado para JSON:");
        Console.WriteLine(pessoa2);
    }
}
}
