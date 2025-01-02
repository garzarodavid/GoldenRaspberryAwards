
# Golden Raspberry Awards API

Esta é uma API RESTful para ler a lista de indicados e vencedores da categoria Pior Filme do Golden Raspberry Awards.

## Requisitos do Sistema

- Ler o arquivo CSV dos filmes e inserir os dados em uma base de dados ao iniciar a aplicação.

## Requisitos da API

- Obter o produtor com maior intervalo entre dois prêmios consecutivos, e o que obteve dois prêmios mais rápido, seguindo a especificação de formato definida abaixo.

## Requisitos Não Funcionais

1. O web service RESTful deve ser implementado com base no nível 2 de maturidade de Richardson;
2. Devem ser implementados somente testes de integração. Eles devem garantir que os dados obtidos estão de acordo com os dados fornecidos na proposta;
3. O banco de dados deve estar em memória utilizando um SGBD embarcado (por exemplo, SQLite com `UseInMemoryDatabase` do Entity Framework). Nenhuma instalação externa deve ser necessária;
4. A aplicação deve conter um readme com instruções para rodar o projeto e os testes de integração.

## Formato da API

### Intervalo de prêmios

```json
{
  "min": [
    {
      "producer": "Producer 1",
      "interval": 1,
      "previousWin": 2008,
      "followingWin": 2009
    },
    {
      "producer": "Producer 2",
      "interval": 1,
      "previousWin": 2018,
      "followingWin": 2019
    }
  ],
  "max": [
    {
      "producer": "Producer 1",
      "interval": 99,
      "previousWin": 1900,
      "followingWin": 1999
    },
    {
      "producer": "Producer 2",
      "interval": 99,
      "previousWin": 2000,
      "followingWin": 2099
    }
  ]
}
```

## Instruções para Rodar o Projeto

1. Clone o repositório:
   ```sh
   git clone https://github.com/garzarodavid/GoldenRaspberryAwards.git
   cd GoldenRaspberryAwards
   ```

2. Compile e execute o projeto:
   ```sh
   dotnet build
   dotnet run
   ```

3. A aplicação estará disponível em `http://localhost:5000` (ou a porta que você configurou).

## Testes de Integração

Para rodar os testes de integração, execute:
```sh
dotnet test
```

## Tecnologias Utilizadas

- .NET 8
- C#
- Entity Framework Core (com SQLite in-memory)
- CSVHelper (para leitura do arquivo CSV)
