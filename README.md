# CRUD Minimal API - Person

API RESTful desenvolvida com ASP.NET Core Minimal API para gerenciamento de pessoas.

## Tecnologias

- [.NET 10.0](https://dotnet.microsoft.com/)
- [ASP.NET Core Minimal API](https://learn.microsoft.com/pt-br/aspnet/core/fundamentals/minimal-apis)
- [OpenAPI / Swagger](https://swagger.io/)

## Estrutura do Projeto

```
├── Models/
│   └── PersonModel.cs        # Modelo de dados
├── DTOs/
│   └── PersonRequest.cs      # Requests de entrada
├── Services/
│   └── PersonService.cs      # Lógica de negócio (in-memory)
├── Routes/
│   └── PersonRoute.cs        # Definição dos endpoints
└── Program.cs                # Ponto de entrada
```

## Endpoints

| Método   | Rota              | Descrição               |
|----------|-------------------|-------------------------|
| `GET`    | `/person`         | Lista todas as pessoas  |
| `GET`    | `/person/{id}`    | Busca pessoa por ID     |
| `POST`   | `/person`         | Cria uma pessoa         |
| `PUT`    | `/person/{id}`    | Atualiza uma pessoa     |
| `DELETE` | `/person/{id}`    | Remove uma pessoa       |

## Como Rodar

```bash
# Restaurar dependências
dotnet restore

# Compilar
dotnet build

# Rodar
dotnet run
```

A API estará disponível em:
- HTTP: `http://localhost:5210`
- Swagger: `http://localhost:5210/openapi/v1.json`

## Exemplos de Uso

### Criar pessoa

```http
POST /person
Content-Type: application/json

{
  "name": "João Silva"
}
```

### Listar pessoas

```http
GET /person
```

### Buscar por ID

```http
GET /person/{id}
```

### Atualizar pessoa

```http
PUT /person/{id}
Content-Type: application/json

{
  "name": "João Santos"
}
```

### Remover pessoa

```http
DELETE /person/{id}
```

## Licença

[BSD 2-Clause](LICENSE)
