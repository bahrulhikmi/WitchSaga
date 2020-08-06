# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY *.sln .
COPY WitchSagaCore/*.csproj WitchSagaCore/
COPY WitchSagaWeb/*.csproj WitchSagaWeb/
COPY WitchSagaTests/*.csproj WitchSagaTests/
RUN dotnet restore
COPY . .

# testing
FROM build AS testing
WORKDIR /src/WitchSagaCore
RUN dotnet build
WORKDIR /src/WitchSagaWeb
RUN dotnet build
WORKDIR /src/WitchSagaTests
RUN dotnet test

# publish
FROM build AS publish
WORKDIR /src/WitchSagaWeb
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
# ENTRYPOINT ["dotnet", "WitchSagaWeb.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WitchSagaWeb.dll