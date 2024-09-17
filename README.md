# GiniLytics Code Base 
## Overview

This project is a **.NET Core MVC** application that follows an N-Tier architecture pattern with:
- **UI Layer**: The Presentation Layer (MVC) for user interaction.
- **Service Layer**: Contains business logic and acts as an intermediary between the UI and Repository Layer.
- **Repository Layer**: Handles database interactions.
- **Model Layer**: Defines the application's data models and shared entities.
- **Test Layer**: Contains unit tests for services, repositories, and other components.

### UI Layer
- **Controllers**: Handle HTTP requests and return views or JSON data.
- **Views**: Razor views used for displaying UI elements.
- **wwwroot**: Static files (JS, CSS, images) for the front-end.

### Service Layer
- **Interfaces**: Contracts for the business logic services.
- **Implementations**: Business logic implementation classes. This layer interacts with the Repository Layer to retrieve data.

### Repository Layer
- **Interfaces**: Define methods for database access (CRUD operations).
- **Implementations**: Classes implementing the repository interfaces, handling database operations.

### Model Layer
- **Entities**: Core business entities or database models.
- **DTOs**: Data Transfer Objects for communication between layers.

### Test Layer
- **UnitTests**: Contains unit tests for individual components (Services, Repositories, etc.).
- **IntegrationTests**: Contains integration tests to test how the layers work together.

## Technologies Used
- **.NET Core** (vX.X)
- **Entity Framework Core** or **Dapper** (for Data Access)
- **SQL Server** (or other databases)
- **ASP.NET Core MVC**
- **XUnit/NUnit/MSTest** (for testing)
- **MoQ** or **NSubstitute** (for mocking dependencies in tests)
- **Dependency Injection** for managing dependencies
