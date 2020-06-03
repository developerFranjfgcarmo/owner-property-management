# Owner Property Management

## Structure

```
fullstack-owner-property-management
├── OwnerPropertyManagement.Api --> Web Api.
├── OwnerPropertyManagement.App--> Angular Client.
├── OwnerPropertyManagement.Contracts --> Contracts of The WebApi
├── OwnerPropertyManagement.Data --> Persistence Layers
├── OwnerPropertyManagement.Domain --> Logic and access to data
└── OwnerPropertyManagement.Test --> Test
```
## Getting started.
1. Sql Server. The connectionstring is configured for a instance of local Sql Server:"" and with windows Authentication
```
"Server=.\\;Database=OwnerProperty;Trusted_Connection=True;"
```
These settings can be changed in the file: appsettings.json for the application to work and in the DesignTimeDbContextFactory  class for migrations to work too.
2. Migrations. Set the project OwnerPropertyManagement.Data and run the command Updata-Database from Package Manager Console.
3. AngularApp run with Visual Studio with the option View Browser or with visual studio code, pre-installing the extension live Server.
4. Set the project OwnerPropertyManagement.Api and run the project.
5. Users: admin/admin or user/user.

## How it work
Asp.Net core:
- CQRS.
- JWT authentication using ASP.NET Core JWT Bearer Authentication.
- SeriLog.
- Automapper.
- Entity Framework Core.
- Dapper. Micro Orm, it used for complex queries
- Xunit
- FluentValidation. Api contract validation
- Sqlite.To test EF core.
- Swagger. End points: https://localhost:44311/swagger/index.html

Angular:
- ui-bootstrap
- AngularJs
- Auth basic.
- Toaster.
- Angular-loading-bar

