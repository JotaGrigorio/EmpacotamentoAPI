using Microsoft.AspNetCore.Mvc;
using EmpacotamentoAPI.Dtos;
using EmpacotamentoAPI.Services;
using EmpacotamentoAPI.Services.Interfaces;

namespace EmpacotamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpacotamentoController : ControllerBase  
    {
        private readonly IEmpacotamentoService _empacotamentoService;
        private readonly ICaixasService _caixasDisponiveisService;

        public EmpacotamentoController(EmpacotamentoService empacotamentoService, CaixasService caixasDisponiveisService)
        {
            _empacotamentoService = empacotamentoService;
            _caixasDisponiveisService = caixasDisponiveisService;
        }

        [HttpPost("processar-pedidos")]
        public IActionResult ProcessarPedidos([FromBody] PedidosRequestDto request)
        {
            if (request?.Pedidos == null || !request.Pedidos.Any())
                return BadRequest("A lista de pedidos é obrigatória.");

            var caixasDisponiveis = _caixasDisponiveisService.ObterCaixas();

            var resultados = request.Pedidos.Select(pedido =>
            {
                var resultado = _empacotamentoService.EmpacotarProdutos(pedido.Produtos, caixasDisponiveis);

                var produtosEmpacotados = resultado.SelectMany(kvp => kvp.Value).ToList();

                var produtosNaoEmpacotados = pedido.Produtos.Except(produtosEmpacotados).ToList();

                var caixasFormatadas = resultado.Select(kvp => new CaixaEmpacotadaDto
                {
                    CaixaId = kvp.Key.Nome,
                    Produtos = kvp.Value.Select(p => p.Id).ToList(),
                    Observacao = kvp.Value.Count == 0 ? "Produto não cabe em nenhuma caixa disponível." : null
                }).ToList();

                if (produtosNaoEmpacotados.Any())
                {
                    caixasFormatadas.Add(new CaixaEmpacotadaDto
                    {
                        CaixaId = null,
                        Produtos = produtosNaoEmpacotados.Select(p => p.Id).ToList(),
                        Observacao = "Produto não cabe em nenhuma caixa disponível."
                    });
                }

                return new
                {
                    pedido_id = pedido.Id,
                    caixas = caixasFormatadas
                };
            });

            return Ok(new { pedidos = resultados });
        }

    }

}