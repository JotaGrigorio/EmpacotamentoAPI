namespace EmpacotamentoAPI.Models
{
    public class Caixa
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public Dimensoes Dimensoes { get; set; } = new Dimensoes();

        public List<Produto> Produtos { get; set; } = new List<Produto>();

    }
}

