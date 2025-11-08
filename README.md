🎧 NoisEmap — Sistema de Mapeamento Sonoro Urbano

Disciplina: Advanced Business Development with .NET
Professor: Marcel Stefan Wagner
Alunos:

Rafael Terra Teodoro (RM560955)

Enzo Elia Tarraga (RM560901)

Otoniel Arantes Barbado (RM560112)

---

🎯 Objetivo

O NoisEmap é uma aplicação voltada para o monitoramento, registro e análise de níveis de ruído em áreas urbanas, promovendo o uso de dados ambientais para apoiar o planejamento urbano sustentável e a criação de políticas públicas de redução da poluição sonora.

---

📦 Escopo e Entregas
🧩 Sprint 1 — Estrutura e Arquitetura do Projeto

Implementações realizadas:

* Estruturação completa em camadas seguindo o padrão **Clean Architecture**:
    * Domain: Entidades e interfaces de contrato
    * Application: Regras de negócio e serviços
    * Infrastructure: Persistência de dados e repositórios
    * API: Exposição de endpoints e configuração do Swagger
* Configuração do Entity Framework Core com SQL Server LocalDB
* Implementação da injeção de dependência entre camadas
* Configuração e funcionamento do Swagger para documentação automática da API

🚀 Sprint 2 — Implementação da Camada Web (ASP.NET Core Web API)

Entregas realizadas:

* Criação dos **Controllers RESTful** com operações **CRUD** completas
* Implementação de busca com **paginação e filtros dinâmicos**
* Testes de endpoints via Swagger e Postman
* **Atualização do README.md** e adição de instruções completas de execução

---

🧱 Arquitetura do Projeto (Clean Architecture)
NoisEmap
│
├── NoisEmap.API          # Camada de apresentação (Controllers, Swagger)
├── NoisEmap.Application  # Casos de uso, regras de negócio, serviços
├── NoisEmap.Domain       # Entidades, interfaces e contratos
└── NoisEmap.Infrastructure # Acesso a dados, repositórios e contexto EF Core

---

🧰 Tecnologias Utilizadas

* .NET 9.0 / ASP.NET Core Web API
* Entity Framework Core
* Swagger / OpenAPI
* C# 12
* SQL Server Express LocalDB
* Dependency Injection
* Clean Architecture

---

🔧 Instruções de Instalação e Execução
1️⃣ Clonar o repositório
```bash
git clone [https://github.com/seuusuario/noisemap.git](https://github.com/seuusuario/noisemap.git)
cd noisemap
2️⃣ Configurar o banco de dados

Edite o arquivo appsettings.json na camada API e atualize a string de conexão:

JSON

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=NoisEmapDb;Trusted_Connection=True;"
}
3️⃣ Executar as migrations

Bash

dotnet ef database update
4️⃣ Rodar o projeto

Bash

dotnet run --project NoisEmap.Api
5️⃣ Acessar o Swagger

Abra no navegador:

https://localhost:5055/swagger (Use a porta 5055, conforme visto na sua execução)

🔗 Endpoints Principais | Método | Rota | Descrição | | :--- | :--- | :--- | | GET | /api/Map | Lista todos os mapas sonoros | | GET | /api/Map/{id} | Retorna um mapa específico | | POST | /api/Map | Cria um novo mapa sonoro | | PUT | /api/Map/{id} | Atualiza um mapa existente | | DELETE | /api/Map/{id} | Remove um mapa | | GET | /api/Map/search?termo=centro&page=1&pageSize=10 | Pesquisa com paginação e filtros |

🧠 Exemplo de Requisição (POST)

Endpoint:

POST /api/Map

Body JSON:

JSON

{
  "name": "Mapa Centro SP",
  "description": "Região central - medições de ruído noturno",
  "latitude": -23.5505,
  "longitude": -46.6333,
  "address": "Rua Exemplo, 123" 
}
Resposta (201 Created):

JSON

{
  "id": 1,
  "location": "Rua Exemplo, 123",
  "noiseLevel": 78.5,
  "recordedAt": "2025-11-08T18:00:00Z"
}
🧪 Testes Realizados | Teste | Resultado Esperado | Status | | :--- | :--- | :--- | | Criar novo mapa (POST) | Retorna 201 Created com objeto salvo | ✅ OK | | Listar todos os mapas (GET) | Retorna lista de objetos | ✅ OK | | Buscar por ID (GET /{id}) | Retorna o item correto | ✅ OK | | Atualizar mapa (PUT) | Retorna 204 No Content | ✅ OK | | Deletar mapa (DELETE) | Retorna 204 No Content | ✅ OK | | Buscar com termo (Search) | Retorna lista filtrada e paginada | ✅ OK | | Swagger carregando | Interface funcional | ✅ OK |

📈 Progresso do Desenvolvimento | Entrega | Implementações | Status | | :--- | :--- | :--- | | 1ª Entrega | Estrutura base, entidades, EF Core e DI | ✅ Concluída | | 2ª Entrega | Controllers, CRUD, busca e testes | ✅ Concluída | | Próximas Etapas | Interface visual (Blazor) e integração externa | 🔜 Planejado |

🧩 Conclusão

O NoisEmap apresenta uma arquitetura sólida e escalável, baseada em boas práticas de Clean Architecture, Injeção de Dependência e Entity Framework Core. O sistema está pronto para evoluir com novas camadas de visualização (ex.: Blazor) e módulos de análise geoespacial.

👨‍💻 Autor

Rafael Terra Teodoro RM560955 – Advanced Business Development with .NET

💯 Observação Final

Este README documenta de forma completa o desenvolvimento das Sprints 1 e 2, incluindo:

Estrutura técnica do projeto

Tecnologias utilizadas

Endpoints e exemplos reais

Testes realizados

Status de evolução