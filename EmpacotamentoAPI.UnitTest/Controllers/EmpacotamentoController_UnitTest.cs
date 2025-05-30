using Microsoft.AspNetCore.Mvc;
using EmpacotamentoAPI.Controllers;
using EmpacotamentoAPI.Services;
using EmpacotamentoAPI.Models;
using EmpacotamentoAPI.Dtos;

namespace EmpacotamentoAPI.UnitTest.Controllers
{
    [TestClass]
    public class EmpacotamentoControllerTests
    {
        [TestMethod]
        public void ProcessarPedidos_BadRequest_PedidosNulos()
        {
            var controller = new EmpacotamentoController(new EmpacotamentoService(new CaixasService()), new CaixasService());
            var resultado = controller.ProcessarPedidos(null);
            Assert.IsInstanceOfType(resultado, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void ProcessarPedidos_Ok_PedidosValidos()
        {
            var controller = new EmpacotamentoController(new EmpacotamentoService(new CaixasService()), new CaixasService());

            var pedidosRequestDto = new PedidosRequestDto
            {
                Pedidos = new List<Pedido>
                {
                    new Pedido
                    {
                        Id = 1,
                        Produtos = new List<Produto>
                        {
                            new Produto
                            {
                                Id = "Super Nintendo",
                                Dimensoes = new Dimensoes { Altura = 8, Largura = 20, Comprimento = 25 }
                            }
                        }
                    }
                }
            };

            var resultado = controller.ProcessarPedidos(pedidosRequestDto);
            Assert.IsInstanceOfType(resultado, typeof(OkObjectResult));
        }
    }
}
