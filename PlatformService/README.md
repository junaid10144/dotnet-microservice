# .NET Microservices

## PlatformService

### Packages

1. **AutoMapper.Extensions.Microsoft.DependencyInjection**
   - **Explanation**: This package provides integration of AutoMapper with Microsoft Dependency Injection.
   - **Usage**: Used for object-object mapping, which helps in transforming objects from one type to another.
   - **Command**: 
     ```sh
     dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
     ```

2. **Microsoft.EntityFrameworkCore**
   - **Explanation**: This package is the core framework for Entity Framework Core, which is an ORM (Object-Relational Mapper) for .NET.
   - **Usage**: Used for data access and manipulation in a database-agnostic way.
   - **Command**: 
     ```sh
     dotnet add package Microsoft.EntityFrameworkCore
     ```

3. **Microsoft.EntityFrameworkCore.Design**
   - **Explanation**: This package contains design-time tools for Entity Framework Core, such as scaffolding.
   - **Usage**: Used for generating models and migrations during development.
   - **Command**: 
     ```sh
     dotnet add package Microsoft.EntityFrameworkCore.Design
     ```

4. **Microsoft.EntityFrameworkCore.InMemory**
   - **Explanation**: This package provides an in-memory database provider for Entity Framework Core.
   - **Usage**: Useful for testing purposes where a real database is not required.
   - **Command**: 
     ```sh
     dotnet add package Microsoft.EntityFrameworkCore.InMemory
     ```

5. **Microsoft.EntityFrameworkCore.SqlServer**
   - **Explanation**: This package provides a SQL Server database provider for Entity Framework Core.
   - **Usage**: Used for data access and manipulation specifically with SQL Server databases.
   - **Command**: 
     ```sh
     dotnet add package Microsoft.EntityFrameworkCore.SqlServer
     ```