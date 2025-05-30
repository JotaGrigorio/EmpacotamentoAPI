using System.Text.Json.Serialization;

namespace EmpacotamentoAPI.Dtos
{
    public class CaixaEmpacotadaDto
    {
        public string? CaixaId { get; set; }
        public List<string> Produtos { get; set; } = new();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Observacao { get; set; }
    }
}
