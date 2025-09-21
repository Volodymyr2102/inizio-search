# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY inizio-search/inizio-search/inizio-search.csproj ./inizio-search/
RUN dotnet restore ./inizio-search/inizio-search.csproj

COPY . .
RUN dotnet publish inizio-search/inizio-search/inizio-search.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
# Render требует слушать $PORT
ENV ASPNETCORE_URLS=http://0.0.0.0:$PORT
ENTRYPOINT ["dotnet", "inizio-search.dll"]
