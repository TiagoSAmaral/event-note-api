<!--
* README.md 
* event-list 
*
* Created by Tiago Amaral on 05/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
-->

# Event List API

Projeto de API desenvolvido com .Net8. 

Instrucoes de execução: 

- Relatório de cobertura de código: [CLICK AQUI](https://tiagosamaral.github.io/event-note-api/)
- Acesso ao Swagger publicado: [CLICK AQUI](https://event-note-api.onrender.com/swagger/index.html)

## Execução manual do projeto
    
Caso necessário a execução manual do projeto poderá ser feita de duas maneiras: Usando Docker ou Execução diretamente no ambiente local.

### Execução com Docker 

Na raiz do projeto já existe um script para auxiliar na execução do projeto locamente usando o docker. 
Antes é necessário dar permissão de execução ao script. Abra o terminal, navegue até a pasta raiz do projeto `event-list-api`
execute o comando: 

```shell
$ chmod +x start-app-docker.sh
```
E em seguinda execute o script assim: 

```shell
$ ./start-app-docker.sh
```

### Execução no Ambiente Local

Abra o seu terminal, e navegue até a pasta raiz do projeto (event-list-api/) e execute os seguintes comandos: 

Instalar as dependências:

```shell
$ dotnet restore
```
Realizar build do projeto: 
```
$ dotnet build
```
Executar projeto: 

```
$ dotnet run
```

<p>Tanto com a execução no ambiente ou local usando Docker, o Swagger do projeto poderá ser acessado na URL:</p>

- Swagger: **http://localhost:5185/swagger/index.html**
- API: **http://localhost:5185/api/eventos**

## Operações da API 

A API do projeto possui a seguinte rota: 

- **[BASE_URL]/api/eventos** 

A qual da suporte para as seguintes operações e suas ações: 
- **GET**: Lista os eventos cadastrados
- **POST**: Recebe uma requisição com o JSON para registrar novo evento.
- **GET com parâmetro ID**: Recebe o ID de um evento para retornar os dados completos.
- **DELETE com parâmetro ID**: Permite a remoção do evento.

Para mais detalhes consulte o Swagger do projeto.

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
|   ├── Modules/
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