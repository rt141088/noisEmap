# NoisEmap - Sistema de Mapeamento Sonoro Urbano

## 🎯 Objetivo
Permitir o registro, visualização e análise de níveis de ruído em áreas urbanas,
auxiliando no planejamento urbano e políticas ambientais.

## 📦 Escopo
- CRUD de projetos de mapeamento sonoro (MapProjects)
- API REST com ASP.NET Core
- Camadas separadas por responsabilidade (Clean Architecture)
- Integração futura com banco de dados via Entity Framework Core

## 🧱 Arquitetura (Clean Architecture)
- **API (Apresentação):** Controllers, Swagger, Rotas
- **Application:** Serviços (regras de caso de uso)
- **Domain:** Entidades e interfaces de contrato
- **Infrastructure:** Banco de dados, repositórios e contexto

## 🧰 Tecnologias
- ASP.NET Core 8.0
- Entity Framework Core
- Swagger / OpenAPI
- C#
