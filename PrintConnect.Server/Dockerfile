FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PrintConnect.Web/PrintConnect.Web/PrintConnect.Web.csproj", "PrintConnect.Web/PrintConnect.Web/"]
COPY ["PrintConnect.Web/PrintConnect.Web.Client/PrintConnect.Web.Client.csproj", "PrintConnect.Web/PrintConnect.Web.Client/"]
RUN dotnet restore "PrintConnect.Web/PrintConnect.Web/PrintConnect.Web.csproj"
COPY . .
WORKDIR "/src/PrintConnect.Web/PrintConnect.Web"
RUN dotnet build "./PrintConnect.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PrintConnect.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PrintConnect.Web.dll"]
