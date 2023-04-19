# MySimpleBlog
Senior Developer Assessment (Simple Blog)

![Home Page](https://user-images.githubusercontent.com/6513732/233061974-18733c7a-cf5a-45cb-821d-9125931fcabe.png)

This is a simple blog web application developed using ASP.NET Blazor 
 - The application was built using moden development bes practices and it consist of three projects 
    1. MySimpleBlog.Client (Presentation/UI) - PWA (Progressive Web App)
    2. MySimpleBlog.Server (API / Data processing)
    3. MySimpleBlog.Shared (Models, services, DBContext and Interfaces)

API exposure:
====================
  - The APIs are expose to other developers and consumers using Swagger which makes it easier to read json formated data.
![Swagger API accessibility integration](https://user-images.githubusercontent.com/6513732/233062117-9d6ca2d7-e55a-4163-ad04-082583d2a021.png)

Databse:
====================
  - SQL Server database- obtainable in the database directory

Why ASP.NET Blazor and .Net 6 Framework
====================
I chose blazor and .Net 6 Framework after considering systems availability, scalabity, extensibility and consumer (Users) 
  - .Net 6 is still under long-term support with Microsoft which means changes on the framework can still be supported and any further enhancements can be done with ease.
  - Progressive Web Applications enables the use of the application without internet connections, which means our users can enjoy reading articles even when disconnected from their networks or during loadshedding.
  - Blazor makes it easier to manage dynamic views which plays an important role in code and componet reuse and extensibility.
  - This framework made it easier to separate frontend from backend

Libraries Used:
====================
  1. Bootstrap - this was used to create applealing user interfaces
  2. Swagger (Swashbuckle) - This was used to give other developers and consumers a sophisticated way ro read and test APIs
  3. Microsoft.EntityFrameworkCore.Tools and Microsoft.EntityFrameworkCore.SqlServer - was used to create our DBContext and create the database with tables specified on our models

Build Instruction
====================
  1. Clone the Project
  2. Restore Database/MySimpleBlogDB.bak onto your local SQLSever or SQLServer Express machine
  3. Run the MySimpleBlog.Server.csproj application from the command line or Visual Studio 2017 or latest

Enjoy!!!
