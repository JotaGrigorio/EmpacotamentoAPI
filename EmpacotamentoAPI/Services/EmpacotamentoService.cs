using EmpacotamentoAPI.Models;
using EmpacotamentoAPI.Services.Interfaces;

namespace EmpacotamentoAPI.Services
{
    public class EmpacotamentoService : IEmpacotamentoService
    {
        private readonly ICaixasService _caixasService;

        public EmpacotamentoService(CaixasService caixasService)
        {
            _caixasService = caixasService;
        }

        public Dictionary<Caixa, List<Produto>> ProcessarPedido(Pedido pedido)
        {
            var caixas = _caixasService.ObterCaixas();
            return EmpacotarProdutos(pedido.Produtos, caixas);
        }

        public Dictionary<Caixa, List<Produto>> EmpacotarProdutos(List<Produto> produtos, List<Caixa> caixas)
        {
            var resultado = new Dictionary<Caixa, List<Produto>>();
            var produtosRestantes = new List<Produto>(produtos);

            while (produtosRestantes.Any())
            {
                Caixa? melhorCaixa = null;
                List<Produto> melhoresProdutos = new();
                int[]? melhorEspacoRestante = null;

                foreach (var caixa in caixas)
                {
                    var espacoRestante = new[]
                    {
                        caixa.Dimensoes.Altura,
                        caixa.Dimensoes.Largura,
                        caixa.Dimensoes.Comprimento
                    };

                    Array.Sort(espacoRestante);

                    var produtosQueCabem = new List<Produto>();
                    var copiaEspaco = (int[])espacoRestante.Clone();

                    foreach (var produto in produtosRestantes)
                    {
                        var espacoTemp = (int[])copiaEspaco.Clone();
                        if (TentaAcomodarProduto(ref espacoTemp, produto, out _))
                        {
                            produtosQueCabem.Add(produto);
                            copiaEspaco = espacoTemp;
                        }
                    }

                    if (produtosQueCabem.Count > melhoresProdutos.Count)
                    {
                        melhorCaixa = caixa;
                        melhoresProdutos = produtosQueCabem;
                        melhorEspacoRestante = copiaEspaco;
                    }
                }

                if (melhorCaixa != null && melhoresProdutos.Any())
                {
                    var novaCaixa = new Caixa
                    {
                        Nome = melhorCaixa.Nome,
                        Dimensoes = melhorCaixa.Dimensoes
                    };

                    resultado[novaCaixa] = melhoresProdutos;

                    foreach (var p in melhoresProdutos)
                        produtosRestantes.Remove(p);
                }
                else
                {
                    break;
                }
            }

            return resultado;
        }

        private bool TentaAcomodarProduto(ref int[] espacoRestante, Produto produto, out int[] dimensaoUtilizada)
        {
            var rotacoes = new[]
            {
                new[] { produto.Dimensoes.Altura, produto.Dimensoes.Largura, produto.Dimensoes.Comprimento },
                new[] { produto.Dimensoes.Altura, produto.Dimensoes.Comprimento, produto.Dimensoes.Largura },
                new[] { produto.Dimensoes.Largura, produto.Dimensoes.Altura, produto.Dimensoes.Comprimento },
                new[] { produto.Dimensoes.Largura, produto.Dimensoes.Comprimento, produto.Dimensoes.Altura },
                new[] { produto.Dimensoes.Comprimento, produto.Dimensoes.Altura, produto.Dimensoes.Largura },
                new[] { produto.Dimensoes.Comprimento, produto.Dimensoes.Largura, produto.Dimensoes.Altura }
            };

            Array.Sort(espacoRestante);

            foreach (var rotacao in rotacoes)
            {
                var copiaRotacao = (int[])rotacao.Clone();
                Array.Sort(copiaRotacao);

                if (copiaRotacao[0] < espacoRestante[0] &&
                    copiaRotacao[1] < espacoRestante[1] &&
                    copiaRotacao[2] < espacoRestante[2])
                {
                    espacoRestante[2] -= copiaRotacao[2];
                    dimensaoUtilizada = copiaRotacao;
                    return true;
                }
            }

            dimensaoUtilizada = null!;
            return false;
        }

    }
}
