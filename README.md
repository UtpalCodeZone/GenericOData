To generate models using the scaffold command in VS Code, you need to execute the following command:

```
dotnet ef dbcontext scaffold "Server=<server ip / localhost>; Port=<port number>; Database=<Database name>; User Id=<user name>; Password=<password>;" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models/V1/DataModels --context-dir "DbContexts/V1" --context "ApiDbContext" --data-annotations --use-database-names --no-onconfiguring -f
```

To generate models using the scaffold command in Visual Studio, you need to execute the following command:

```
dotnet ef dbcontext scaffold "Server=<server ip / localhost>; Port=<port number>; Database=<Database name>; User Id=<user name>; Password=<password>;" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models/V1/DataModels --context-dir "DbContexts/V1" --context "ApiDbContext" --data-annotations --use-database-names --no-onconfiguring -f --project <.csproj project path for GenericOData.Application>
```

Once the scaffold command has been executed, you need to run the PowerShell script "GenerateFile.ps1".

To execute the PowerShell script, follow these steps:
1. Open a Windows PowerShell window.
2. Navigate to the directory where the script "GenerateFile.ps1" exists (GenericOData.Application).
3. Execute the command: `powershell.exe .\GenerateFile.ps1`

Now you are ready to use the OData APIs.

To run the API
1. Navigate to the API directory (GenericOData.Api).
2. Execute the command: `dotnet run`

Sample scaffold command:

```
dotnet ef dbcontext scaffold "Server=localhost; Port=2024; Database=mytestdb01; User Id=test; Password=valgen@123;" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models/V1/DataModels --context-dir "DbContexts/V1" --context "ApiDbContext" --data-annotations --use-database-names --no-onconfiguring -f
```

To run a local PostgreSQL database in Docker, execute the following command:

```
docker volume create mycitiusdata
docker-compose -p citus up -d
```
