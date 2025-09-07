<!--
* README.md 
* event-list 
*
* Created by Tiago Amaral on 05/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
-->

# 🎯 Desafio Técnico – Desenvolvedor Mobile (Pleno/Sênior)

Este repositório contém o desafio técnico de desenvolvimento de um aplicativo híbrido em **Ionic + Angular**, consumindo uma **API em .NET 6/7 Web API**, com foco em código limpo, escalável, reutilizável e aplicando boas práticas de arquitetura.

---

## 📌 Objetivo Geral
- Criar um sistema composto por **API (backend)** e **aplicativo (frontend)**.
- Permitir **listar, cadastrar e visualizar detalhes de eventos**.
- Demonstrar **organização, boas práticas e clareza na documentação**.

---

## 🏗️ Estrutura do Projeto

```text
root/
└── backend/ # API .NET 6/7 Web API
  ├── Src/
      ├── Core
      ├── Modules
          ├── Eventlist
              ├── Infra
              ├── Services
              └── Storage
      └── shared
          ├── Dtos
          ├── ExceptionsMessage
          ├── Middlewares
          └── ResponseDefault
          
      
  └── README.md

```

## 🔹 Backend (.NET 6/7 Web API)

### 📍 Objetivos
- Expor endpoints REST:
    - `GET /api/eventos`
    - `POST /api/eventos`
    - `GET /api/eventos/{id}`
- Modelar entidade **Evento** com:
    - `id (Guid)`
    - `titulo (string)`
    - `descricao (string)`
    - `data (DateTime)`
    - `local (string)`
- Usar **Entity Framework Core** (InMemory ou SQLite).
- Aplicar boas práticas: **Camadas, Repository Pattern ou CQRS**.
- Incluir validações:
    - Título obrigatório.
    - Data deve ser futura.
- Configurar **Swagger/OpenAPI**.

### ✅ Checklist de Metas
- [X] Criar projeto .NET Web API.
- [X] Configurar EF Core (InMemory ou SQLite).
- [X] Implementar entidade `Evento`.
- [X] Criar repositório e aplicar boas práticas (Repository Pattern / CQRS).
- [X] Implementar validações (título e data).
- [X] Implementar endpoints solicitados.
- [X] Configurar Swagger com documentação.
- [X] Testar CRUD via Swagger ou cliente HTTP.

## 🌟 Diferenciais (opcionais, mas recomendados)

- [ ] Testes unitários (`xUnit` para backend)
- [ ] CI/CD com **GitHub Actions / GitLab CI / Azure DevOps**.
- [ ] Publicar backend no **Azure App Service**.