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

- Relatório de cobertura de código: https://tiagosamaral.github.io/event-note-api/
- Acesso ao Swagger publicado: https://event.api.connectmidia.com/swagger/index.html
- Download de app para teste: https://github.com/TiagoSAmaral/event-list-mobile-app/blob/main/event-list-app-debug.apk
- Projeto app mobile: https://github.com/TiagoSAmaral/event-list-mobile-app

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
