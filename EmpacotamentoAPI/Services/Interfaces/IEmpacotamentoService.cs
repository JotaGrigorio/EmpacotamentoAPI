using EmpacotamentoAPI.Models;

namespace EmpacotamentoAPI.Services.Interfaces
{
    public interface IEmpacotamentoService
    {
        Dictionary<Caixa, List<Produto>> ProcessarPedido(Pedido pedido);

        Dictionary<Caixa, List<Produto>> EmpacotarProdutos(List<Produto> produtos, List<Caixa> caixasDisponiveis);
    }
}
