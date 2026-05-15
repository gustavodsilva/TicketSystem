# TicketSystem

Sistema de gerenciamento de chamados desenvolvido para controle, acompanhamento e organização de tickets de suporte técnico e demandas internas.

O projeto foi desenvolvido utilizando .NET e Entity Framework, com foco em arquitetura em camadas, integração com banco de dados e boas práticas de desenvolvimento de software.

A aplicação tem como objetivo simular um ambiente corporativo de abertura, acompanhamento e gerenciamento de tickets, permitindo evolução contínua da solução e expansão de funcionalidades futuras.

---

# Tecnologias Utilizadas

## Backend

* C#
* .NET
* ASP.NET Core
* Entity Framework Core
* REST API

## Banco de Dados

* SQL Server *(podendo ser adaptado para MySQL/PostgreSQL)*

## Frontend

* HTML5
* CSS3
* JavaScript

## Ferramentas

* Visual Studio
* Git
* GitHub

---

# Estrutura do Projeto

```bash
TicketSystem/
│
├── API/
├── Application/
├── Domain/
├── Infrastructure/
├── Database/
├── Frontend/
└── README.md
```

---

# Funcionalidades

* Cadastro de chamados
* Edição de tickets
* Exclusão de chamados
* Controle de status
* Controle de prioridade
* Acompanhamento de atendimentos
* Histórico de alterações
* Sistema de autenticação *(planejado)*
* Dashboard com indicadores *(planejado)*
* Integração com banco de dados
* Geração de relatórios

---

# Estrutura Inicial do Banco de Dados

## Tabela: Tickets

| Campo         | Tipo     |
| ------------- | -------- |
| Id            | int      |
| Titulo        | varchar  |
| Descricao     | text     |
| Status        | varchar  |
| Prioridade    | varchar  |
| Responsavel   | varchar  |
| DataCriacao   | datetime |
| DataConclusao | datetime |

---

# Como Executar o Projeto

## 1. Clone o repositório

```bash
git clone https://github.com/SEU-USUARIO/TicketSystem.git
```

---

## 2. Abra no Visual Studio

Abra o arquivo:

```bash
TicketSystem.sln
```

---

## 3. Configure a Connection String

No arquivo:

```bash
appsettings.json
```

Configure:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=TicketSystem;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## 4. Execute as Migrations

```bash
Update-Database
```

ou:

```bash
dotnet ef database update
```

---

## 5. Execute o Projeto

```bash
dotnet run
```

---

# Objetivos do Projeto

Este projeto tem como objetivo:

* Praticar arquitetura em camadas
* Aprimorar conhecimentos em .NET
* Trabalhar com Entity Framework
* Aplicar conceitos de banco de dados
* Desenvolver APIs REST
* Criar um sistema real para portfólio
* Simular ambiente corporativo de sustentação e chamados

---

# Roadmap

## Em desenvolvimento

* [ ] Integração completa com banco de dados
* [ ] Sistema de login
* [ ] Controle de usuários
* [ ] Dashboard administrativo
* [ ] Upload de anexos
* [ ] Sistema de comentários
* [ ] Notificações
* [ ] API documentada com Swagger
* [ ] Deploy em nuvem

---

# Futuras Implementações

* Painel Kanban
* Controle SLA
* Chat interno
* Integração com e-mail
* Auditoria de alterações
* Relatórios avançados
* Dark Mode

---

# Autor

## Gustavo Tiano

Analista de Sistemas com experiência em sustentação, automação de processos, integração de sistemas e desenvolvimento Full Stack.

---

# Licença

Este projeto está sob a licença MIT.
