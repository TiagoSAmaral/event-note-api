<!--
* README.md 
* event-list 
*
* Created by Tiago Amaral on 05/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
-->


# Event List

Projeto de teste feito com .Net 8.

Estrutura do Projeto: 


eventList/             
 ┣ Controllers/ → Camada de apresentação (Controllers)
 ┃ ┣ Program.cs
 ┃ ┗ appsettings.json
 ┣ Application/            → Regras de negócio (Services, CQRS Handlers)
 ┃ ┣ Interfaces/
 ┃ ┗ Services/
 ┣ Domain/                 → Entidades, Regras de domínio
 ┃ ┣ Entities/
 ┃ ┗ ValueObjects/
 ┣ Infrastructure/         → Persistência (EF Core, Repositories, Migrations)
 ┃ ┣ Data/
 ┃ ┣ Repositories/
 ┃ ┗ Migrations/
 ┣ MyApi.sln                     → Solution file