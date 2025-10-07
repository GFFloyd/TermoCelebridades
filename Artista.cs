using System.Text;

public class Artista
{
    public string Nome { get; set; }
    public string Genero { get; set; }
    public string Profissao { get; set; }
    public string Nacionalidade { get; set; }
    public int Idade { get; set; }
    public bool Falecido { get; set; }
    public float Altura { get; set; }
    public string Foto { get; set; }
    public string Etnia { get; set; }
    public List<string> Premios { get; set; }

    public Artista(string nome, string genero, string profissao, string nacionalidade, int idade, bool falecido, float altura, string foto, string etnia, List<string> premios)
    {
        Nome = nome;
        Genero = genero;
        Profissao = profissao;
        Nacionalidade = nacionalidade;
        Idade = idade;
        Falecido = falecido;
        Altura = altura;
        Foto = foto;
        Etnia = etnia;
        Premios = premios;
    }

    public override string ToString() => $"Nome: {Nome}\nGênero: {Genero}\nProfissão: {Profissao}\nNacionalidade: {Nacionalidade}\nIdade: {Idade}\nÉ Falecido? {Falecido}\nAltura: {Altura}\nEtnia: {Etnia}\nPrêmios: {PremiosToString(Premios)}";

    public string PremiosToString(List<string> premios)
    {
        var builder = new StringBuilder();
        foreach (var prem in premios)
        {
            if (prem != premios[^1])
                builder.Append($"{prem}, ");
            else
                builder.Append($"{prem}");
        }
        return builder.ToString();
    }
}