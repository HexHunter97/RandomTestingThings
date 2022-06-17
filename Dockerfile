FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 433

#restore all projects
FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src
COPY ArmaReforger.WorkshopBrowser.sln ./
COPY ArmaReforger.WorkshopBrowser/Shared/*.csproj ./ArmaReforger.WorkshopBrowser/Shared/
COPY ArmaReforger.WorkshopBrowser/Client/*.csproj ./ArmaReforger.WorkshopBrowser/Client/
COPY ArmaReforger.WorkshopBrowser/Server/*.csproj ./ArmaReforger.WorkshopBrowser/Server/
RUN dotnet restore

COPY . .

#build in-order
WORKDIR /src/ArmaReforger.WorkshopBrowser/Shared/
RUN dotnet build -c Release -o /app

WORKDIR /src/ArmaReforger.WorkshopBrowser/Client/
RUN dotnet build -c Release -o /app

WORKDIR /src/ArmaReforger.WorkshopBrowser/Server/
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ArmaReforger.WorkshopBrowser.Server.dll"]