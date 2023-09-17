# Sizanani Logistics

Sizanani Logistics is an ASP.NET Core 7 project designed to manage logistics operations for contractors and their vehicles.

## Overview

This project is structured with multiple layers to maintain a clean and organized codebase:

- **Web MVC Project**: `SizananiLogistics.Web` - The user interface layer, responsible for handling user requests and presenting information.
- **Application Layer**: Contains business logic and orchestrates actions between the UI and data access layers. It uses the Infrastructure layer.
- **Infrastructure Layer**: Contains implementations for data access, including SQL database operations. The SQL repository implementations can be found here.
- **Database**: The database is created using Entity Framework Core migrations. You can find migration scripts in the `Database/Scripts` folder.

## Getting Started

To run this project locally, follow these steps:

1. Create the database using the provided migration script located in the `Database/Scripts` folder.

2. Set the startup project to `SizananiLogistics.Web`.

3. Configure the database connection string in `InfrastructureConstants.Database`.

## Technologies Used

- ASP.NET Core 7
- SQL Server (for data storage)
- Razor Pages (for the user interface)
- Bootstrap (for styling)
