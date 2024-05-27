Welcome to the eCommerce project! This repository contains the source code for a modern, scalable eCommerce platform built using .NET. This project aims to provide a comprehensive solution for building and managing online stores with ease.

Table of Contents
About
Technologies Used
Features
Getting Started
Prerequisites
Installation
Running the Application
Project Structure
Contributing
License
Contact
About
This project is an eCommerce API built using .NET. It serves as the backend for an eCommerce application, providing endpoints for managing products, orders, customers, and more. The project follows the Clean Architecture pattern, splitting the project into different class libraries, such as Domain, Application, and Infrastructure. The project uses Entity Framework for database communication, alongside the repository pattern, abstracting the use of Entity Framework and making it possible to switch to any other ORM.

Technologies Used
C#
ASP.NET Core
Entity Framework Core
SQL Server (or any preferred database)
Features
User Authentication: Secure registration and login system.
Product Management: Interface for adding, editing, and deleting products.
Shopping Cart: Interactive shopping cart with real-time updates.
Order Processing: Efficient order management and tracking.
Payment Integration: Secure payment gateway integration.
Admin Dashboard: Comprehensive admin panel for managing the store.
Scalable Architecture: Built with scalability in mind to handle high traffic.
Getting Started
Prerequisites
Ensure you have the following installed on your local machine:

.NET Core SDK (v5.0 or later)
SQL Server (or any preferred database)
Installation
Clone the repository:

git clone https://github.com/lukasvanide/eCommerce.git
cd eCommerce
Install dependencies:

dotnet restore
Set up the database:

Create a database in your preferred database server (e.g., SQL Server, MySQL, PostgreSQL).
Update the connection string in appsettings.json with your database connection details.
Run the migrations:

dotnet ef database update
Running the Application
Start the development server:

dotnet run
Open your browser and navigate to http://localhost:5000 to view the application.

Project Structure
Shop.Application: Contains the application logic and services.
Shop.Domain: Contains the domain models and business logic.
Shop.Infrastructure: Contains the database context, configurations, and migrations.
Shop: Main project containing the API controllers and startup configuration.
.gitignore: Specifies files to ignore in the repository.
README.md: This file.
Shop.sln: Solution file for the project.
Contributing
We welcome contributions to improve this project! Please follow these steps to contribute:

Fork the repository.
Create a new branch (git checkout -b feature/your-feature-name).
Commit your changes (git commit -m 'Add some feature').
Push to the branch (git push origin feature/your-feature-name).
Create a Pull Request.
Please make sure to update tests as appropriate and adhere to the project's coding guidelines.

License
This project is licensed under the MIT License. See the LICENSE file for details.

Contact
If you have any questions or feedback, feel free to reach out:

Project Maintainer: Lukas Vanide (Replace with actual email)
Thank you for checking out the eCommerce project! We hope you find it useful and look forward to your contributions.
