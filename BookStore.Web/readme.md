# BookStore.WebAPI

This is an ASP.NET Core Web API for managing a bookstore. It provides endpoints for CRUD operations on books.

## Features
- Get all books
- Get book by ID
- Add a new book
- Update book details
- Delete a book

## Technologies Used
- ASP.NET Core 9.0
- Entity Framework Core
- AutoMapper
- xUnit & Moq for unit testing

## Getting Started

### Prerequisites
- .NET 9.0 SDK
- SQL Server (or change connection string for another provider)

### Build and Run
1. Restore dependencies:
   ```bash
   dotnet restore
   ```
2. Build the project:
   ```bash
   dotnet build
   ```
3. Run the API:
   ```bash
   dotnet run --project BookStore.Web/BookStore.WebAPI.csproj
   ```

### Running Tests
```bash
dotnet test BookStore.Tests/BookStore.WebAPI.Tests.csproj
```

## API Endpoints
- `GET /api/BookStore` - Get all books
- `GET /api/BookStore/{id}` - Get book by ID
- `POST /api/BookStore` - Add a new book
- `PUT /api/BookStore/{id}` - Update book
- `DELETE /api/BookStore/{id}` - Delete book

## Project Structure
- `BookStore.Web/` - Main Web API project
- `BookStore.Tests/` - Unit test project

## License
MIT
