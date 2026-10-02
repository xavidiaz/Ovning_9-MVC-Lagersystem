# Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish Ovning_9.csproj -c Release -o /app

# Run
FROM mcr.microsoft.com/dotnet/aspnet:10.0
LABEL org.opencontainers.image.source=https://github.com/xavidiaz/Ovning_9-MVC-Lagersystem
WORKDIR /app
COPY --from=build /app .
# The app opens "storage.db" in the folder it starts in, and writes to it.
# The server runs containers read-only with a writable /tmp, so every start
# begins from a fresh copy of the seeded database there; the views and
# wwwroot are still found through the content root.
COPY storage.db /app/seed/storage.db
ENV ASPNETCORE_CONTENTROOT=/app
USER $APP_UID
EXPOSE 8080
ENTRYPOINT ["/bin/sh", "-c", "cp /app/seed/storage.db /tmp/storage.db && cd /tmp && exec dotnet /app/Ovning_9.dll"]
