using EmpacotamentoAPI.Models;

namespace EmpacotamentoAPI.Dtos
{
    public class PedidosRequestDto
    {
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
