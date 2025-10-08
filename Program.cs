using System.Text.Json;
using System.Text.Json.Nodes;
public class Program
{
    private static void Main(string[] args)
    {
        const string jsonPath = "/home/gfaraco/termo/test.json";
        var teste = new Artista(
            "Brad Pitt",
            "homem",
            "ator",
            "estadunidense",
            55,
            false,
            1.70f,
            "",
            "branco",
            ["Globo de Ouro", "BAFTA"]
            );
        Console.WriteLine(Path.GetFullPath(jsonPath));
        AdicionarArtistaAoJSON(jsonPath, teste);
    }
    public static void AdicionarArtistaAoJSON(string path, Artista artist)
    {
        var options = new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
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
}