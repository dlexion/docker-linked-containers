FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /dotnetapp
COPY out .
ENTRYPOINT ["dotnet", "Cities.dll"]