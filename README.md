# GenericOData
Generic Api using OData 8
# When execute scaffold command through vs code need to execute below type command to generate models

dotnet ef dbcontext scaffold "Server=<server ip / localhost>; Port=<port number>; Database=<Database name>; User Id=<user name>; Password=<password>;" 
Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models/V1/DataModels --context-dir "DbContexts/V1" --context "ApiDbContext" --data-annotations 
--use-database-names --no-onconfiguring -f

# When execute scaffold command through visual studio need to execute below type command to generate models

dotnet ef dbcontext scaffold "Server=<server ip / localhost>; Port=<port number>; Database=<Database name>; User Id=<user name>; Password=<password>;" 
Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models/V1/DataModels --context-dir "DbContexts/V1" --context "ApiDbContext" --data-annotations 
--use-database-names --no-onconfiguring -f --project <.csprog project path for GenericOData.Application>

# once above scaffold command executed then execute powershell script "GenerateFile.ps1"

# To execute the powershell script follow below steps.
# step 1: Open window powershell
# step 2: Go to the GenericOData.Application directory where the script "GenerateFile.ps1" exist.
# step 2: execute command --- powershell.exe .\GenerateFile.ps1

## Now you are ready to use odata api's


# Sample scaffold command

dotnet ef dbcontext scaffold "Server=localhost; Port=2024; Database=mytestdb01; User Id=test; Password=valgen@123;" Npgsql.EntityFrameworkCore.PostgreSQL 
--output-dir Models/V1/DataModels --context-dir "DbContexts/V1" --context "ApiDbContext" --data-annotations --use-database-names --no-onconfiguring -f


# To run local postgres db in docker execute below code using docker command
# execute docker-compose.yml file from GenericOData.Core/Sample and follow the below command

docker volume create mycitiusdata  
docker-compose -p citus up -d

