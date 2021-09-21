#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ms.employees/ms.employees.api/ms.employees.api.csproj", "ms.employees/ms.employees.api/"]
COPY ["ms.employees/ms.employees.application/ms.employees.application.csproj", "ms.employees/ms.employees.application/"]
COPY ["ms.employees/ms.employees.domain/ms.employees.domain.csproj", "ms.employees/ms.employees.domain/"]
COPY ["ms.employees/ms.employees.infrastructure/ms.employees.infrastructure.csproj", "ms.employees/ms.employees.infrastructure/"]
RUN dotnet restore "ms.employees/ms.employees.api/ms.employees.api.csproj"
COPY . .
WORKDIR "/src/ms.employees/ms.employees.api"
RUN dotnet build "ms.employees.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ms.employees.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ms.employees.api.dll"]
