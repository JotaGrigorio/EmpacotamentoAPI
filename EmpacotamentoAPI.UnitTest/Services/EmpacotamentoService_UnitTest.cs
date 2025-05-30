using EmpacotamentoAPI.Services;
using EmpacotamentoAPI.Models;

namespace EmpacotamentoAPI.UnitTest.Services
{
    [TestClass]
    public class EmpacotamentoServiceTests
    {
        private EmpacotamentoService? _empacotamentoService;

        [TestInitialize]
        public void Setup()
        {
            var caixasService = new CaixasService();
            _empacotamentoService = new EmpacotamentoService(caixasService);
        }

        [TestMethod]
        public void EmpacotarProdutos_ComListaDeProdutos_Ok()
        {
            var produtos = new List<Produto>
            {
                new Produto { Id = "Mega Drive", Dimensoes = new Dimensoes { Altura = 6, Largura = 22, Comprimento = 22} },
                new Produto { Id = "32X", Dimensoes = new Dimensoes { Altura = 10, Largura = 11, Comprimento = 21 } }
            };
            var caixasDisponiveis = new CaixasService().ObterCaixas();

            var resultado = _empacotamentoService?.EmpacotarProdutos(produtos, caixasDisponiveis);

            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Count > 0);
        }
    }
}
