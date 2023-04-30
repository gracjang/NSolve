FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NSolve.Api/NSolve.Api.csproj", "NSolve.Api/"]
RUN dotnet restore "NSolve.Api/NSolve.Api.csproj"
COPY . .
WORKDIR "/src/NSolve.Api"
RUN dotnet build "NSolve.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSolve.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSolve.Api.dll"]
