#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MotorMenezes.Web/MotorMenezes.Web.csproj", "MotorMenezes.Web/"]
COPY ["MotorMenezes.Domain/MotorMenezes.Domain.csproj", "MotorMenezes.Domain/"]
COPY ["MotorMenezes.Core/MotorMenezes.Core.csproj", "MotorMenezes.Core/"]
COPY ["MotorMenezes.Infra.Data/MotorMenezes.Infra.Data.csproj", "MotorMenezes.Infra.Data/"]
COPY ["MotorMenezes.Infra.Log/MotorMenezes.Infra.Log.csproj", "MotorMenezes.Infra.Log/"]
RUN dotnet restore "./MotorMenezes.Web/MotorMenezes.Web.csproj"
COPY . .
WORKDIR "/src/MotorMenezes.Web"
RUN dotnet build "./MotorMenezes.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MotorMenezes.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MotorMenezes.Web.dll"]