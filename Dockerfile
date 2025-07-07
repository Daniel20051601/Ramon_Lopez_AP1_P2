FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Ramon_Lopez_AP1_P2.csproj", "./"]
RUN dotnet restore "Ramon_Lopez_AP1_P2.csproj"

COPY . .
RUN dotnet publish "Ramon_Lopez_AP1_P2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Ramon_Lopez_AP1_P2.dll"]