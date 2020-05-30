dotnet tool install --global dotnet-ef --version 3.1.4
dotnet tool update --global dotnet-ef --version 3.1.4
dotnet ef --startup-project ../MaterialAspNetCoreBackend.WebApp/ database update
pause