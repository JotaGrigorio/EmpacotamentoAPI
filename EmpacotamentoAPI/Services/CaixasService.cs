using EmpacotamentoAPI.Models;
using EmpacotamentoAPI.Services.Interfaces;

namespace EmpacotamentoAPI.Services
{
    public class CaixasService : ICaixasService
    {
        public List<Caixa> ObterCaixas()
        {
            return new List<Caixa>   
            {
                new Caixa
                {
                    Id = 1,
                    Nome = "Caixa 1",
                    Dimensoes = new Dimensoes { Altura = 30, Largura = 40, Comprimento = 80 }
                },
                new Caixa
                {
                    Id = 2,
                    Nome = "Caixa 2",
                    Dimensoes = new Dimensoes { Altura = 80, Largura = 50, Comprimento = 40 }
                },
                new Caixa
                {
                    Id = 3,
                    Nome = "Caixa 3",
                    Dimensoes = new Dimensoes { Altura = 50, Largura = 80, Comprimento = 60 }
                }
            };
        }
    }
}
