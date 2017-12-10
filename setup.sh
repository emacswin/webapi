dotnet new sln
mkdir webapi
cd webapi
dotnet new webapi
dotnet add package Autofac
dotnet add package Autofac.Extensions.DependencyInjection
dotnet add package MongoDB.Driver

cd ..
mkdir webapi_test
dotnet new xunit
dotnet add reference ../webapi/webapi.csproj
dotnet add package Microsoft.AspNetCore.Mvc
dotnet restore

dotnet sln webapi.sln add webapi/webapi.csproj
dotnet sln webapi.sln add webapi_test/webapi_test.csproj
