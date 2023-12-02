FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY API/*.csproj ./API/
RUN dotnet restore

COPY . .

CMD ["dotnet", "watch", "run", "--project", "API/API.csproj"]

# WORKDIR /app/API
# RUN dotnet build -c Release -o out

# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
# WORKDIR /app
# COPY --from=build /app/API/out ./

# ENTRYPOINT ["dotnet", "API.dll"]