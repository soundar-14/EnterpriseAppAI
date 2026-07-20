# EnterpriseAppAI - Foundation Implementation Guide

## Objective

Build a production-ready foundation before implementing AI features.

**Goal:** Learn enterprise .NET architecture while using GitHub Copilot effectively instead of generating everything manually.

---

# Project Structure

```
EnterpriseAppAI.sln

src
│
├── EnterpriseAppAI.API
├── EnterpriseAppAI.Application
├── EnterpriseAppAI.Domain
├── EnterpriseAppAI.Infrastructure
├── EnterpriseAppAI.Shared

tests
└── EnterpriseAppAI.Tests
```

---

# Learning Rules

For every step:

1. Learn the concept (10–15 minutes)
2. Ask GitHub Copilot to generate a basic implementation
3. Read and understand the generated code
4. Refactor if needed
5. Test the implementation
6. Commit to Git

Never copy code without understanding it.

---

# Step 1 - Clean Architecture

## Objective

Separate responsibilities into different layers.

### Domain

Contains:

- Entities
- Value Objects
- Enums
- Domain Interfaces
- Domain Events

No Entity Framework.

No ASP.NET.

No external libraries.

---

### Application

Contains:

- Use Cases
- CQRS
- DTOs
- Interfaces
- Validators
- Business Rules

No database code.

---

### Infrastructure

Contains:

- Entity Framework Core
- Repository Implementations
- Unit of Work
- Azure Services
- Logging
- Email
- AI Services (later)

---

### API

Contains:

- Controllers
- Middleware
- Authentication
- Dependency Injection
- Swagger

Contains no business logic.

---

# Copilot Prompt

"Generate a Clean Architecture folder structure for an ASP.NET Core application with Domain, Application, Infrastructure, and API projects following SOLID principles."

---

# Step 2 - Dependency Injection

## Objective

Register every service using constructor injection.

Avoid static classes.

Avoid service locator.

---

Implement:

- Repository registration
- UnitOfWork registration
- Services registration
- MediatR registration
- FluentValidation registration

---

Copilot Prompt

"Generate Dependency Injection extension methods for Infrastructure and Application projects using IServiceCollection."

---

# Step 3 - Repository Pattern

## Objective

Create a reusable repository.

Implement

- IRepository<T>
- GenericRepository<T>

Methods

- GetByIdAsync
- GetAllAsync
- FindAsync
- AddAsync
- Update
- Delete

Use Entity Framework Core.

---

Copilot Prompt

"Generate a generic repository pattern using Entity Framework Core for ASP.NET Core."

---

# Step 4 - Unit Of Work

## Objective

Manage transactions.

Implement

IUnitOfWork

Methods

- SaveChangesAsync()

Expose repositories through UnitOfWork.

---

Copilot Prompt

"Generate Unit of Work implementation using Entity Framework Core."

---

# Step 5 - CQRS

## Objective

Separate reads from writes.

Folder Structure

```
Application

Features

Employee

Commands

Queries
```

Create

- CreateEmployeeCommand
- UpdateEmployeeCommand
- DeleteEmployeeCommand
- GetEmployeeQuery
- GetEmployeesQuery

---

Copilot Prompt

"Generate CQRS command and query handlers using MediatR."

---

# Step 6 - MediatR

Implement

- IRequest
- IRequestHandler

Pipeline Behaviors

- Logging
- Validation
- Performance

---

Copilot Prompt

"Generate MediatR handlers and pipeline behaviors."

---

# Step 7 - Validation

Use

FluentValidation

Validate

- Create Employee
- Create Ticket
- Upload Document

---

Copilot Prompt

"Generate FluentValidation validators for CreateEmployeeCommand."

---

# Step 8 - Global Exception Middleware

Implement

- Problem Details
- Logging
- Validation Exception
- NotFound Exception
- Unauthorized Exception

---

Copilot Prompt

"Generate ASP.NET Core global exception middleware following RFC7807."

---

# Step 9 - Logging

Use

ILogger

Add

- Request logging
- Response logging
- Exception logging

Later

Application Insights

---

# Step 10 - Authentication

Implement

- JWT
- Refresh Token (optional)
- Role Based Authorization

Roles

- Employee
- Manager
- HR
- IT
- Admin

---

# Step 11 - Database

Create

- Users
- Departments
- ChatSessions
- ChatMessages
- Documents

Seed sample data.

---

# Step 12 - Testing

Use

- xUnit
- Moq

Test

- Repository
- Handlers
- Services

---

# Git Commit Strategy

Commit after every completed concept.

Example

```
feat: setup clean architecture

feat: implement dependency injection

feat: add generic repository

feat: implement unit of work

feat: add CQRS using MediatR

feat: add FluentValidation

feat: add global exception middleware

feat: implement JWT authentication
```

---

# Definition of Done

- Project builds successfully.
- No compiler warnings.
- Swagger works.
- Database migrations succeed.
- Dependency Injection validates successfully.
- CRUD endpoints work.
- Unit tests pass.

---

# Ready for AI

Only after all the above is complete, begin implementing:

- Azure OpenAI
- Semantic Kernel
- Prompt Engineering
- Function Calling
- RAG
- Azure AI Search
- Azure AI Foundry
- Document Intelligence
- MCP
- AI Agents