# Clean Architecture

1. Domain Layer
    * Core business logic and domain models
    * Contains entities, value objects and business rules/logic

2. Application Layer
    * Use cases and orchestrating the domain layer
    * Contains Services, Commands, Queries; that interact with domain layer
    * Acts as a mediator between domain layer and user interface

3. Infrastructure Layer
    * Providing technical services: data access, email, logging, security
    * Contains the adapters that implement the ports required by the application and the infrastructure-specific details.

4. Presentation/API Layer
    * Display application data and user interface
    * Contains user interfaces, controllers and views that interact with application

## How To

### 1. Create solution
```
$ mkdir project

## create new solution
$ dotnet new sln -n project

## see list of projects
$ dotnet sln project list
```

### 2. Create Core/Domain layer
```
$ dotnet new classlib -o Core/Domain -n Core.Domain

$ dotnet sln project.sln add Core/Domain
```

### 3. Create Core/Application layer
```
$ dotnet new classlib -o Core/Application -n Core.Application

$ dotnet sln project.sln add Core/Application
```

### 4. Create Infrastructure layer
```
$ dotnet new classlib -o Infrastructure/Infrastructure -n Infrastructure.Infrastructure

$ dotnet sln project.sln add Infrastructure/Infrastructure
```

### 5. Create Persistence layer
The Persistence layer is a specific type of Infrastructure layer that is responsible for managing the storage and retrieval of data from a database or other persistent data store. The Persistence layer includes the data access objects (DAOs) and repositories that implement the data access logic for the application.
```
$ dotnet new classlib -o Infrastructure/Persistence -o Infrastructure.Persistence

$ dotnet sln project.sln add Infrastructure/Persistence
```

### 6. Create API/Host layer
```
$ dotnet new webapi -f net7.0 -o Presentation/API -n Presentation.API

$ dotnet sln project.sln add Presentation/API
```

### 7. Wire up references between the projects
In order for the projects to work when we start the development of the application, we have to add some references between them. Below are the commands you should use to wire them together.

Reference domain project inside application project
```
$ dotnet add Core/Application/Application.csproj reference Core/Domain/Domain.csproj
```

```
dotnet add Infrastructure/Infrastructure/Infrastructure.csproj reference Core/Application/Application.csproj

dotnet add Infrastructure/Persistence/Persistence.csproj reference Core/Application/Application.csproj

dotnet add Presentation/API/API.csproj reference Infrastructure/Infrastructure/Infrastructure.csproj

dotnet add Presentation/API/API.csproj reference Infrastructure/Persistence/Persistence.csproj
```

Now we have wired up the references for our projects so that the application layer references the domain layer and the presentation/API layer references the infrastructure and domain too.





