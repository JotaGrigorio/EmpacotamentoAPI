# EmpacotamentoAPI

## 📦 Descrição do Projeto

Seu Manoel tem uma loja de jogos online e deseja automatizar o processo de embalagem dos pedidos. Ele precisa de uma API que, dado um conjunto de pedidos com produtos e suas dimensões, retorne quais caixas devem ser usadas para cada pedido e quais produtos irão em cada caixa.

Este projeto é uma API desenvolvida em .NET 8 que recebe pedidos via JSON e calcula a melhor forma de empacotar os produtos nas caixas disponíveis.

---

## 🚀 Funcionalidades Implementadas

✅ Receber uma lista de pedidos via JSON, onde cada pedido possui produtos com dimensões (altura, largura, comprimento).  
✅ Calcular a melhor forma de embalar os produtos usando as caixas pré-definidas:
- Caixa 1: 30 x 40 x 80
- Caixa 2: 80 x 50 x 40
- Caixa 3: 50 x 80 x 60

✅ Retornar um JSON com as caixas utilizadas e os produtos alocados em cada uma.  
✅ Swagger configurado para teste da API.  
✅ Testes unitários implementados para validação da lógica de empacotamento.

---

## 📂 Estrutura do Projeto
EmpacotamentoAPI/
└── EmpacotamentoSolution/
├── EmpacotamentoAPI/ # Projeto principal (API)
└── EmpacotamentoAPIUnitTest/ # Testes unitários

## 📝 Como Executar

> **Pré-requisitos**:
> - .NET 8 instalado (SDK)

### Passos para executar:

# Clone o repositório
git clone https://github.com/JotaGrigorio/EmpacotamentoAPI.git

# Acesse a pasta da solução
cd EmpacotamentoAPI/EmpacotamentoSolution/EmpacotamentoAPI

# Execute o projeto
dotnet run

A aplicação estará disponível em:
https://localhost:{porta}/swagger

Abra o navegador e teste a API via Swagger.

## 🧪 Testes
Para rodar os testes unitários:

cd EmpacotamentoAPI/EmpacotamentoSolution/EmpacotamentoAPIUnitTest
dotnet test

## 🛠️ Tecnologias Utilizadas
.NET 8
C#
Swagger (Swashbuckle)
MSTest

