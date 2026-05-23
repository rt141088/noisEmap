# NoisEmap API

Sistema de monitoramento de sensores ambientais com arquitetura limpa, integração MongoDB Atlas e API RESTful completa.

---

## 👥 Integrantes

| Nome | RM |
|---|---|
| Rafael Terra Teodoro | RM560955 |
| Enzo Elia Tarraga | RM560901 |
| Otoniel Arantes Barbado | RM560112 |

---

## 🏗️ Arquitetura da Solução

```
NoisEmap/
├── NoisEmap.Api/              # Camada de Apresentação
│   ├── Controllers/
│   │   └── TestController.cs  # Endpoints REST + JWT
│   ├── Program.cs             # Configuração da aplicação
│   └── appsettings.json       # Configurações (DB, MongoDB, Logging)
│
├── NoisEmap.Application/      # Camada de Aplicação
│   └── Services/
│       └── SensorService.cs   # Regras de negócio
│
├── NoisEmap.Domain/           # Camada de Domínio
│   ├── Entities/
│   │   └── Sensor.cs          # Entidade principal
│   └── Interfaces/
│       ├── ISensorRepository.cs
│       └── ISensorMongoRepository.cs
│
├── NoisEmap.Infrastructure/   # Camada de Infraestrutura
│   ├── Data/
│   │   └── AppDbContext.cs    # Entity Framework Core
│   └── Repositories/
│       ├── SensorRepository.cs       # Repositório SQL Server
│       └── SensorMongoRepository.cs  # Repositório MongoDB Atlas
│
├── NoisEmap.UnitTests/        # Testes Unitários (xUnit + Moq)
└── NoisEmap.IntegrationTests/ # Testes de Integração
```

### Diagrama de Camadas

```
[Cliente / Swagger]
        │
        ▼
[NoisEmap.Api] ──── Controllers, JWT, Swagger, HealthCheck
        │
        ▼
[NoisEmap.Application] ──── SensorService (regras de negócio)
        │
        ▼
[NoisEmap.Domain] ──── Entities, Interfaces (contratos)
        │
        ▼
[NoisEmap.Infrastructure] ──── SQL Server (EF Core) + MongoDB Atlas
```

---

## 🚀 Como Executar

### Pré-requisitos

- .NET 8 SDK
- Visual Studio 2022 ou VS Code
- Conta MongoDB Atlas (gratuita)

### Instalação

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/noisemap.git
cd noisemap

# Restaure os pacotes
dotnet restore

# Execute a API
cd NoisEmap.Api
dotnet run
```

A API estará disponível em: `http://localhost:5000`  
Swagger UI em: `http://localhost:5000/swagger`

### Configuração do MongoDB

No arquivo `appsettings.json`:

```json
{
  "MongoDB": {
    "ConnectionString": "mongodb+srv://<usuario>:<senha>@cluster0.xxxxx.mongodb.net",
    "Database": "NoisEmapDb"
  }
}
```

---

## 📡 Endpoints

### Autenticação

| Método | Endpoint | Descrição | Auth |
|--------|----------|-----------|------|
| POST | `/api/test/login` | Gera token JWT | Não |

**Exemplo de uso:**
```bash
curl -X POST http://localhost:5000/api/test/login
```
**Resposta:**
```json
{ "token": "eyJhbGci..." }
```

Use o token nas chamadas protegidas:
```
Authorization: Bearer eyJhbGci...
```

---

### Sensores

| Método | Endpoint | Descrição | Auth |
|--------|----------|-----------|------|
| GET | `/api/test?page=1&size=10` | Lista sensores com paginação e HATEOAS | ✅ |
| GET | `/api/test/{id}` | Busca sensor por ID | Não |
| POST | `/api/test` | Cria novo sensor | Não |
| PUT | `/api/test/{id}` | Atualiza sensor | Não |
| DELETE | `/api/test/{id}` | Remove sensor | Não |

**Body para POST/PUT:**
```json
{
  "temperatura": 25.5,
  "umidade": 60.0
}
```

**Resposta GET com HATEOAS:**
```json
{
  "page": 1,
  "size": 10,
  "total": 1,
  "items": [
    {
      "data": {
        "mongoId": "6a1117e7572c5c5c119b6eb0",
        "id": 0,
        "temperatura": 25.5,
        "umidade": 60
      },
      "_links": {
        "self": "/api/test/0",
        "update": "/api/test/0",
        "delete": "/api/test/0"
      }
    }
  ],
  "_links": {
    "self": "/api/test?page=1&size=10",
    "next": "/api/test?page=2&size=10",
    "prev": null
  }
}
```

---

### Monitoramento

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/health` | Status da aplicação |

---

## 🧪 Testes

### Executar testes unitários

```bash
cd NoisEmap.UnitTests
dotnet test
```

**Resultado esperado:** 7 testes passando, 0 falhas.

### Testes implementados

| Teste | Tipo | Descrição |
|-------|------|-----------|
| `Add_TemperaturaValida_AdicionaSensor` | Unitário | Sensor válido salva no MongoDB |
| `Add_TemperaturaInvalida_LancaExcecao` | Unitário | Temperatura > 100 lança exceção |
| `Add_TemperaturaAbaixoDoMinimo_LancaExcecao` | Unitário | Temperatura < -50 lança exceção |
| `Add_Invalido_NaoInsereMongo` | Unitário | Sensor inválido não é inserido |
| `GetById_SensorExistente_RetornaSensor` | Unitário | Busca por ID existente retorna sensor |
| `GetById_SensorInexistente_RetornaNull` | Unitário | Busca por ID inexistente retorna null |
| `Delete_SensorExistente_ChamaRepositorio` | Unitário | Delete chama o repositório corretamente |

---

## 🔧 Tecnologias Utilizadas

| Tecnologia | Uso |
|---|---|
| .NET 8 | Framework principal |
| ASP.NET Core | API RESTful |
| Entity Framework Core | ORM para SQL Server |
| MongoDB.Driver | Integração NoSQL |
| MongoDB Atlas | Banco NoSQL na nuvem |
| JWT Bearer | Autenticação |
| Serilog | Logging estruturado |
| Swagger / OpenAPI | Documentação da API |
| xUnit | Testes unitários |
| Moq | Mock para testes |

---

## ✅ Funcionalidades Implementadas

- [x] Clean Architecture com 4 camadas separadas
- [x] Princípios SOLID e Clean Code
- [x] Injeção de Dependência configurada
- [x] Tratamento de exceções global (middleware)
- [x] API RESTful completa (CRUD)
- [x] Documentação Swagger/OpenAPI
- [x] Paginação implementada
- [x] HATEOAS nos endpoints de consulta
- [x] Autenticação JWT
- [x] Entity Framework Core (SQL Server)
- [x] MongoDB Atlas integrado
- [x] Padrão Repository implementado
- [x] Health Check configurado (`/health`)
- [x] Logging estruturado com Serilog
- [x] Testes unitários com padrão AAA (xUnit + Moq)