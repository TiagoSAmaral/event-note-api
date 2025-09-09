<!--
* README.md 
* event-list 
*
* Created by Tiago Amaral on 05/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
-->

# Event List API

Projeto desenvolvido usando .NET 8.
Pr

# 🎯 Desafio Técnico – Desenvolvedor Mobile (Pleno/Sênior)

Este repositório contém o desafio técnico de desenvolvimento de um aplicativo híbrido em **Ionic + Angular**, consumindo uma **API em .NET 6/7 Web API**, com foco em código limpo, escalável, reutilizável e aplicando boas práticas de arquitetura.

---

## 📌 Objetivo Geral
- Criar um sistema composto por **API (backend)**.
- Permitir **listar, cadastrar e visualizar detalhes de eventos**.
- Demonstrar **organização, boas práticas e clareza na documentação**.

---

## 🏗️ Estrutura do Projeto

```text
event-list/
├── Src/
|   ├── Core/
|   ├── Mo dules/
|   |    └── Eventlist/
|   |       ├── Infra/
|   |       ├── Services/
|   |       └── Storage/
|   └── shared/
|       ├── Dtos/
|       ├── ExceptionsMessage/
|       ├── Middlewares/
|       └── ResponseDefault/
└── README.md 
```

## 🔹 Backend (.NET 6/7 Web API)

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

- [X] Testes unitários (`xUnit` para backend)
- [X] CI/CD com **GitHub Actions / GitLab CI / Azure DevOps. -> Utilizado o RENDER**
- [X] Publicar backend no **Azure App Service**.

## 🔹 Frontend (Ionic + Angular)

### 📍 Objetivos
- Criar app com **três telas**:
    - Lista de Eventos.
    - Detalhes do Evento.
    - Cadastro de Evento.
- Consumir endpoints da API para listar, detalhar e cadastrar.
- Usar boas práticas de modularização.
- Implementar **validações no formulário**.
- Usar **RxJS/Observables** na integração com a API.

### ✅ Checklist de Metas
- [ ] Criar projeto Ionic + Angular.
- [ ] Configurar módulos e rotas.
- [ ] Implementar tela **Lista de Eventos** (GET /api/eventos).
- [ ] Implementar tela **Detalhes do Evento** (GET /api/eventos/{id}).
- [ ] Implementar tela **Cadastro de Evento** (POST /api/eventos).
- [ ] Aplicar validações no formulário.
- [ ] Usar RxJS/Observables para consumo de API.
- [ ] Testar fluxo completo (listar → detalhar → cadastrar).

## 🌟 Diferenciais (opcionais, mas recomendados)

- [ ] Testes unitários (`Jasmine/Karma` para frontend).
- [ ] Uso de interceptors no Ionic para tratar erros de API.
- [ ] Publicar frontend no **TestFlight** (iOS) ou **APK Android**.

## 🚀 Entrega
- Repositório Git (GitHub/GitLab/Bitbucket) contendo:
- Código-font``e do **app (Ionic)**.
- Código-fonte da **API (.NET Web API)**.
- Instruções claras no `README.md` de cada stack para rodar o projeto.
``

## 📝 Avaliação

O que será analisado:
- Organização do código e estrutura de pastas.
- Uso de boas práticas (SOLID, Clean Code, modularização).
- Clareza nas instruções e documentação.
- Qualidade da integração **API ↔ Mobile**.
- Criatividade na solução.

📅 **Prazo sugerido**: 3 a 5 dias úteis.