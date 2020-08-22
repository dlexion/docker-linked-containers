FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /dotnetapp
COPY out .
ENTRYPOINT ["dotnet", "Cities.dll"]