using System.Net.WebSockets;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
public class Program
{
    private static void Main(string[] args)
    {
        const string jsonPath = "/home/gfaraco/termo/test.json";
        var options = new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        // var teste = new Artista(
        //     "Brad Pitt",
        //     "homem",
        //     "ator",
        //     "estadunidense",
        //     55,
        //     false,
        //     1.70f,
        //     "",
        //     "branco",
        //     ["Globo de Ouro", "BAFTA"]
        //     );
        // var artista = GetArtista();
        // AdicionarArtistaAoJSON(jsonPath, artista, options);
        RemoverArtistaDoJSON(jsonPath, "Joãozinho", options);
    }
    public static void AdicionarArtistaAoJSON(string path, Artista artist, JsonSerializerOptions options)
    {
        JsonArray jsonArray;

        if (File.Exists(path) && new FileInfo(path).Length > 0)
        {
            var jsonAtual = File.ReadAllText(path);
            jsonArray = JsonNode.Parse(jsonAtual) as JsonArray ?? [];
        }
        else
            jsonArray = [];

        var artistaNode = JsonSerializer.SerializeToNode(artist, options);
        jsonArray.Add(artistaNode);

        File.WriteAllText(path, jsonArray.ToJsonString(options));
    }
    public static void RemoverArtistaDoJSON(string path, string nome, JsonSerializerOptions options)
    {
        JsonArray jsonArray;
        if (File.Exists(path) && new FileInfo(path).Length > 0)
        {
            var jsonAtual = File.ReadAllText(path);
            jsonArray = JsonNode.Parse(jsonAtual) as JsonArray ?? [];
            for (int i = jsonArray.Count - 1; i >= 0; i--)
            {
                if (jsonArray[i] is JsonObject artista && artista["nome"]?.GetValue<string>() == nome)
                {
                    jsonArray.RemoveAt(i);
                }
            }
            if (jsonArray.Count - 1 == jsonAtual.Length)
                Console.WriteLine("Nenhum artista com este nome.");

            string jsonAtualizado = jsonArray.ToJsonString(options);
            File.WriteAllText(path, jsonAtualizado);
        }
    }
    public static Artista GetArtista()
    {
        string nome, genero, profissao, nacionalidade, foto, etnia;
        int idade = 0;
        float altura = 0;
        bool falecido = false;
        List<string> premios = [];

        Console.Write("Digite o nome: ");
        nome = Console.ReadLine();
        Console.Write("Digite o genero: ");
        genero = Console.ReadLine();
        Console.Write("Digite a profissão: ");
        profissao = Console.ReadLine();
        Console.Write("Digite a nacionalidade: ");
        nacionalidade = Console.ReadLine();
        Console.Write("Digite o link para a foto: ");
        foto = Console.ReadLine();
        Console.Write("Digite a etnia: ");
        etnia = Console.ReadLine();
        Console.Write("Qual a idade? ");
        idade = int.Parse(Console.ReadLine());
        Console.Write("Qual a altura? ");
        altura = float.Parse(Console.ReadLine());
        Console.Write("O artista já faleceu? ");
        falecido = bool.Parse(Console.ReadLine());
        Console.Write("Digite as premiações do artista: ");
        premios = GetPremios().ToList();

        return new Artista(nome, genero, profissao, nacionalidade, idade, falecido, altura, foto, etnia, premios);
    }
    public static IEnumerable<string> GetPremios()
    {
        var premios = new List<string>();
        while (true)
        {
            Console.Write("Digite um prêmio (ou Enter para finalizar): ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                break;
                
            premios.Add(input);
        }
    
        return premios;
    }
}
