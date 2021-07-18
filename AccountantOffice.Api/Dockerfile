FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AccountantOffice.Api/AccountantOffice.Api.csproj", "AccountantOffice.Api/"]
RUN dotnet restore "AccountantOffice.Api/AccountantOffice.Api.csproj"
COPY . .
WORKDIR "/src/AccountantOffice.Api"
RUN dotnet build "AccountantOffice.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AccountantOffice.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccountantOffice.Api.dll"]
