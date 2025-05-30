using System.Text.Json.Serialization;

namespace EmpacotamentoAPI.Models
{
    public class Pedido
    {
        [JsonPropertyName("pedido_id")]
        public int Id { get; set; }

        public List<Produto> Produtos { get; set; } = new List<Produto>();

    }
}