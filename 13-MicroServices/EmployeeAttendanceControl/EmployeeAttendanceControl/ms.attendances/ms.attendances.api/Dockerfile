#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ms.attendances/ms.attendances.api/ms.attendances.api.csproj", "ms.attendances/ms.attendances.api/"]
COPY ["ms.attendances/ms.attendances.application/ms.attendances.application.csproj", "ms.attendances/ms.attendances.application/"]
COPY ["ms.attendances/ms.attendances.domain/ms.attendances.domain.csproj", "ms.attendances/ms.attendances.domain/"]
COPY ["ms.attendances/ms.attendances.infrastructure/ms.attendances.infrastructure.csproj", "ms.attendances/ms.attendances.infrastructure/"]
RUN dotnet restore "ms.attendances/ms.attendances.api/ms.attendances.api.csproj"
COPY . .
WORKDIR "/src/ms.attendances/ms.attendances.api"
RUN dotnet build "ms.attendances.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ms.attendances.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ms.attendances.api.dll"]
