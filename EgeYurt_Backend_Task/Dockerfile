#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["/EgeYurt_Backend_Task.csproj", "EgeYurt_Backend_Task/"]
RUN dotnet restore "./EgeYurt_Backend_Task/./EgeYurt_Backend_Task.csproj"
COPY . .
WORKDIR "/src/EgeYurt_Backend_Task"
RUN dotnet build "./EgeYurt_Backend_Task.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EgeYurt_Backend_Task.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EgeYurt_Backend_Task.dll"]