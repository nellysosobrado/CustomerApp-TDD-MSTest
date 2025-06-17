# CustomerApp-TDD-MSTest

This is a web application built with ASP.NET Core Razor Pages and Entity Framework Core using the Code First approach. It is designed to manage customer information in a structured, maintainable, and scalable way.

## Project Overview

The application allows users to:

- View a list of all customers  
- Search customers by name  
- Add new customers via a form  
- Select a country from a dropdown populated from the database  
- Filter specific types of customers (e.g., those with specific names)

## Architecture

The project follows a clean separation of concerns and is structured into multiple layers:

- Razor Pages (Frontend) – Handles user interface and interaction  
- Class Library – Contains:
  - Data Transfer Objects (DTOs) for transferring customer data  
  - Services for business logic  
  - The database context for interacting with the database  
- Test Project (MSTest + Moq) – Contains unit tests built to validate functionality and explore test-driven development using MSTest

## Technologies Used

- ASP.NET Core Razor Pages  
- Entity Framework Core (Code First)  
- SQL Server  
- Dependency Injection  
- Data Transfer Objects (DTO)  
- Service Layer architecture  
- MSTest and Moq for unit testing and mocking

## Testing

This project is intentionally built to include and demonstrate unit testing using MSTest. The test project includes tests for all core CRUD operations (Create, Read, Update, Delete) for customer data.

- MSTest is used as the main test framework  
- Moq is used to mock services and dependencies, enabling isolated testing  

These tests help ensure application logic works as intended and make the project a learning resource for writing reliable, maintainable code with test coverage.

## NuGet Packages Used

This project uses the following NuGet packages:

- Microsoft.EntityFrameworkCore  
- Microsoft.EntityFrameworkCore.SqlServer  
- Microsoft.EntityFrameworkCore.Tools  
- Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation  
- Microsoft.AspNetCore.Mvc.ViewFeatures  
- Microsoft.VisualStudio.Web.CodeGeneration.Design  
- MSTest.TestFramework  
- Moq  

## Purpose

The main goal of this project is to demonstrate best practices in .NET web development and automated testing, including:

- Clean, layered architecture  
- Use of DTOs to separate data and presentation logic  
- Clear separation between services and database logic  
- Structured unit testing using MSTest and Moq  
- Scalable and maintainable code for real-world scenarios  

## Getting Started

To run this project locally:

1. Clone the repository from GitHub  
2. Run database migrations to generate the schema  
3. Launch the application using `dotnet run`  
4. Run tests using `dotnet test`


