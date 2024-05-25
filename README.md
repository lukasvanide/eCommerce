This project is an ecommerce API built using .NET. It serves as the backend for an ecommerce application, providing endpoints for managing products, orders, customers, and more.
This project follows Clean Architecture pattern, the project is split in different class libraries, such as Domain, Web, Application and Infrastructure. Project uses Entity framework for DB communication,
alongside with repository pattern, abstracting use of Entity framework and making it possible to switch it out for any other ORM.
I built this project for educational purposes, main goal was to get to know all the technologies mentioned, and how they orchestrate with each other.

## Getting Started

To get started with this project, follow these steps:

1. **Clone the repository**:
2. **Install dependencies**:
3. **Set up the database**: 
- Create a database in your preferred database server (e.g., SQL Server, MySQL, PostgreSQL).
- Update the connection string in `appsettings.json` with your database connection details.
4. **Run the migrations**
5. **Run the application**
