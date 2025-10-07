using System.Text.Json;
var jsonPath = "test.json";
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

// Console.WriteLine(teste);
//to-do: abrir o JSON e escrever o objeto serializado ao final do arquivo
var options = new JsonSerializerOptions { WriteIndented = true };
var serialized = JsonSerializer.Serialize(teste);
using StreamWriter sw = File.AppendText(jsonPath);
// Console.WriteLine(sw.ReadToEnd());
sw.WriteLine(serialized, options);
sw.Close();
