FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /SimpleStore/StoreApp/StoreApp.Webapp

COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out


# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /SimpleStore/StoreApp/StoreApp.Webapp
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "aspnetapp.dll"]