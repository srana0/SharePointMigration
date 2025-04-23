# SharePointMigration

This ASP.NET Core-based application facilitates data and document migration from legacy systems into SharePoint Online using modern authentication, REST APIs, and Entity Framework Core. The solution follows a modular and layered architecture and supports multilingual environments.

## Features

- ASP.NET Core 3.1 Web Application (MVC)
- Service-Oriented Architecture with reusable service layer
- Entity Framework Core with Code-First Migrations
- Secure authentication and role-based authorization
- SharePoint REST integration
- Multi-language support (via resource files)
- Responsive Razor Views using Bootstrap
- DevOps-ready project structure

## Technologies Used

- .NET Core 3.1
- ASP.NET Core MVC
- Entity Framework Core
- SharePoint CSOM / REST API
- Microsoft Identity
- Bootstrap 4
- Visual Studio 2022
- Git for Source Control

## Setup Instructions

1. Clone the repository.
2. Configure `appsettings.json` for authentication and SharePoint.
3. Run migrations:
4. Run the project:


## Folder Structure

- `Controllers/`: MVC Controllers for routing
- `Services/`: Business logic and SharePoint integration
- `Data/`, `Models/`, `Migrations/`: Entity Framework setup
- `Views/`: Razor UI for front-end

## Authors

Developed and maintained by [Subhabrata Rana](https://github.com/srana0).
