🎧 NoisEmap — Sistema de Mapeamento Sonoro Urbano

Disciplina: Advanced Business Development with .NET
Professor: Marcel Stefan Wagner
Alunos:

Rafael Terra Teodoro (RM560955)

Enzo Elia Tarraga (RM560901)

Otoniel Arantes Barbado (RM560112)

🎯 Objetivo

O NoisEmap é uma aplicação voltada para o monitoramento, registro e análise de níveis de ruído em áreas urbanas, promovendo o uso de dados ambientais para apoiar o planejamento urbano sustentável e a criação de políticas públicas de redução da poluição sonora.

📦 Escopo e Entregas
🧩 Sprint 1 — Estrutura e Arquitetura do Projeto

Implementações realizadas:

Estruturação completa em camadas seguindo o padrão Clean Architecture:

Domain: Entidades e interfaces de contrato

Application: Regras de negócio e serviços

Infrastructure: Persistência de dados e repositórios

API: Exposição de endpoints e configuração do Swagger

Configuração do Entity Framework Core com SQL Server LocalDB

Implementação da injeção de dependência entre camadas

Configuração e funcionamento do Swagger para documentação automática da API

🚀 Sprint 2 — Implementação da Camada Web (ASP.NET Core Web API)

Entregas realizadas:

Criação dos Controllers RESTful com operações CRUD completas

Implementação de busca com paginação e filtros dinâmicos

Aplicação de HATEOAS nas respostas da API

Testes de endpoints via Swagger e Postman

Atualização do README.md e adição de instruções completas de execução

🧱 Arquitetura do Projeto (Clean Architecture)
NoisEmap
│
├── NoisEmap.API              # Camada de apresentação (Controllers, Swagger)
├── NoisEmap.Application      # Casos de uso, regras de negócio, serviços
├── NoisEmap.Domain           # Entidades, interfaces e contratos
└── NoisEmap.Infrastructure   # Acesso a dados, repositórios e contexto EF Core

🧰 Tecnologias Utilizadas

.NET 9.0 / ASP.NET Core Web API

Entity Framework Core

Swagger / OpenAPI

C# 12

SQL Server Express LocalDB

Dependency Injection

Clean Architecture

🔧 Instruções de Instalação e Execução
1️⃣ Clonar o repositório
git clone https://github.com/seuusuario/noisemap.git
cd noisemap

2️⃣ Configurar o banco de dados

Edite o arquivo appsettings.json na camada API e atualize a string de conexão:

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=NoisEmapDb;Trusted_Connection=True;"
}

3️⃣ Executar as migrations
dotnet ef database update

4️⃣ Rodar o projeto
dotnet run

5️⃣ Acessar o Swagger

Abra no navegador:

https://localhost:5001/swagger

🔗 Endpoints Principais
Método	Rota	Descrição
GET	/api/map	Lista todos os mapas sonoros
GET	/api/map/{id}	Retorna um mapa específico
POST	/api/map	Cria um novo mapa sonoro
PUT	/api/map/{id}	Atualiza um mapa existente
DELETE	/api/map/{id}	Remove um mapa
GET	/api/map/search?termo=centro&page=1&pageSize=10	Pesquisa com paginação e filtros
🧠 Exemplo de Requisição (POST)

Endpoint:

POST /api/map


Body JSON:

{
  "nome": "Mapa Centro SP",
  "descricao": "Região central - medições de ruído noturno",
  "latitude": -23.5505,
  "longitude": -46.6333,
  "nivelRuido": 78.5
}


Resposta:

{
  "id": 1,
  "nome": "Mapa Centro SP",
  "descricao": "Região central - medições de ruído noturno",
  "latitude": -23.5505,
  "longitude": -46.6333,
  "nivelRuido": 78.5,
  "links": {
    "self": "https://localhost:5001/api/map/1",
    "update": "https://localhost:5001/api/map/1",
    "delete": "https://localhost:5001/api/map/1"
  }
}

🧪 Testes Realizados
Teste	Resultado Esperado	Status
Criar novo mapa (POST)	Retorna 201 Created com objeto salvo	✅ OK
Listar todos os mapas (GET)	Retorna lista de objetos	✅ OK
Buscar por ID (GET /{id})	Retorna o item correto	✅ OK
Atualizar mapa (PUT)	Retorna 204 No Content	✅ OK
Deletar mapa (DELETE)	Retorna 204 No Content	✅ OK
Buscar com termo (Search)	Retorna lista filtrada e paginada	✅ OK
Swagger carregando	Interface funcional	✅ OK
📈 Progresso do Desenvolvimento
Entrega	Implementações	Status
1ª Entrega	Estrutura base, entidades, EF Core e DI	✅ Concluída
2ª Entrega	Controllers, CRUD, busca, HATEOAS e testes	✅ Concluída
Próximas Etapas	Interface visual (Blazor) e integração externa	🔜 Planejado
🧩 Conclusão

O NoisEmap apresenta uma arquitetura sólida e escalável, baseada em boas práticas de Clean Architecture, Injeção de Dependência e Entity Framework Core.
O sistema está pronto para evoluir com novas camadas de visualização (ex.: Blazor) e módulos de análise geoespacial.

👨‍💻 Autor

Rafael Terra Teodoro
RM560955 – Advanced Business Development with .NET

💯 Observação Final

Este README documenta de forma completa o desenvolvimento das Sprints 1 e 2, incluindo:

Estrutura técnica do projeto
🎧 NoisEmap - Sistema de Mapeamento Sonoro Urbano

Disciplina: Advanced Business Development with .NET
Professor: — Marcel Stefan Wagner
Alunos: Rafael Terra Teodoro (RM560955)
        Enzo Elia Tarraga (RM560901)
        Otoniel Arantes Barbado (RM560112)
        
🎯 Objetivo

O projeto NoisEmap tem como propósito permitir o registro, visualização e análise de níveis de ruído em áreas urbanas, fornecendo dados que possam apoiar o planejamento urbano sustentável e políticas públicas ambientais.

📦 Escopo e Entregas
🧩 Entrega 1 – Estrutura e Arquitetura do Projeto

Estrutura em camadas (Clean Architecture):

Domain: Entidades e interfaces de contrato

Application: Regras de negócio e serviços

Infrastructure: Persistência e repositórios

API: Exposição de endpoints e configuração do Swagger

Configuração de Entity Framework Core com SQL Server

Injeção de dependência entre camadas

Swagger configurado e funcional

🚀 Entrega 2 – Implementação da Camada Web (ASP.NET Core Web API)

Criação de Controllers RESTful com operações CRUD completas

Implementação da rota de busca com paginação e filtros

Aplicação de HATEOAS nas respostas da API

Atualização do README.md e instruções de instalação

Testes básicos de endpoints via Swagger/Postman

🧱 Arquitetura (Clean Architecture)
NoisEmap
│
├── NoisEmap.API              # Camada de apresentação (Controllers, Swagger)
├── NoisEmap.Application      # Casos de uso, regras de negócio, serviços
├── NoisEmap.Domain           # Entidades, interfaces e contratos
└── NoisEmap.Infrastructure   # Acesso a dados, repositórios e contexto EF Core

🧰 Tecnologias Utilizadas

.NET 9.0 / ASP.NET Core Web API

Entity Framework Core

Swagger / OpenAPI

C# 12

SQL Server Express LocalDB

Dependency Injection e Clean Architecture

🔧 Instruções de Instalação e Execução

Clonar o repositório:

git clone https://github.com/seuusuario/noisemap.git
cd noisemap


Configurar o banco de dados no appsettings.json:

"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=NoisEmapDb;Trusted_Connection=True;"
}


Executar as migrations:

dotnet ef database update


Rodar o projeto:

dotnet run


Acessar a documentação da API (Swagger):

https://localhost:5001/swagger

🔗 Endpoints Principais
Método	Rota	Descrição
GET	/api/map	Lista todos os mapas sonoros
GET	/api/map/{id}	Retorna um mapa específico
POST	/api/map	Cria um novo mapa sonoro
PUT	/api/map/{id}	Atualiza um mapa existente
DELETE	/api/map/{id}	Remove um mapa
GET	/api/map/search?termo=centro&page=1&pageSize=10	Pesquisa com paginação e filtros
🧠 Exemplo de Requisição (POST)

Endpoint:
POST /api/map

Body JSON:

{
  "nome": "Mapa Centro SP",
  "descricao": "Região central - medições de ruído noturno",
  "latitude": -23.5505,
  "longitude": -46.6333,
  "nivelRuido": 78.5
}


Resposta:

{
  "id": 1,
  "nome": "Mapa Centro SP",
  "descricao": "Região central - medições de ruído noturno",
  "latitude": -23.5505,
  "longitude": -46.6333,
  "nivelRuido": 78.5,
  "links": {
    "self": "https://localhost:5001/api/map/1",
    "update": "https://localhost:5001/api/map/1",
    "delete": "https://localhost:5001/api/map/1"
  }
}

🧪 Testes Básicos Realizados
Teste	Resultado Esperado	Situação
Criar novo mapa (POST)	Retorna 201 Created com objeto salvo	✅ OK
Listar todos os mapas (GET)	Retorna lista de objetos	✅ OK
Buscar por ID (GET /{id})	Retorna o item com ID específico	✅ OK
Atualizar mapa (PUT)	Retorna 204 No Content	✅ OK
Deletar mapa (DELETE)	Retorna 204 No Content	✅ OK
Buscar com termo (Search)	Retorna lista filtrada e paginada	✅ OK
Swagger carregando	Interface funcional de testes	✅ OK
📈 Progresso do Desenvolvimento
Entrega	Implementações	Status
1ª Entrega	Estrutura base, entidades, DI e EF Core	✅ Concluída
2ª Entrega	Controllers, CRUD, busca, HATEOAS e README atualizado	✅ Concluída
Próximas etapas	Interface visual (Blazor) e integração externa	🔜 Planejado
🧩 Conclusão

O NoisEmap apresenta uma arquitetura sólida baseada em boas práticas de desenvolvimento corporativo com .NET, aplicando conceitos de Clean Architecture, Injeção de Dependência, Entity Framework Core, Minimal API e HATEOAS.
O sistema está pronto para expansão e integração com novas camadas de visualização e análise geoespacial.

👨‍💻 Autor

Rafael Terra Teodoro
RM560955 – Advanced Business Development with .NET

💯 Observação Final:

Este README agora:

Tecnologias utilizadas
Explica o progresso do projeto

Endpoints e exemplos reais
Mostra testes básicos realizados

Testes realizados
Detalha endpoints com exemplos reais

Status de evolução
Usa formatação e seções profissionais
