using System.Text.Json.Serialization;

namespace EmpacotamentoAPI.Models
{
    public class Produto
    {
        [JsonPropertyName("produto_id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("dimensoes")]
        public Dimensoes Dimensoes { get; set; } = new Dimensoes();
    }
}