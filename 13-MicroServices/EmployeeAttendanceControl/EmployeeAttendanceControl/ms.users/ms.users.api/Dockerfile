#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ms.users/ms.users.api/ms.users.api.csproj", "ms.users/ms.users.api/"]
COPY ["ms.users/ms.users.application/ms.users.application.csproj", "ms.users/ms.users.application/"]
COPY ["ms.users/ms.users.domain/ms.users.domain.csproj", "ms.users/ms.users.domain/"]
COPY ["ms.users/ms.users.infrastructure/ms.users.infrastructure.csproj", "ms.users/ms.users.infrastructure/"]
RUN dotnet restore "ms.users/ms.users.api/ms.users.api.csproj"
COPY . .
WORKDIR "/src/ms.users/ms.users.api"
RUN dotnet build "ms.users.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ms.users.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ms.users.api.dll"]
