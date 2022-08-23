#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WkCommerce.WebApi/WkCommerce.WebApi.csproj", "WkCommerce.WebApi/"]
COPY ["WkCommerce.Domain/WkCommerce.Domain.csproj", "WkCommerce.Domain/"]
COPY ["WkCommerce.Infrastucture/WkCommerce.Infrastucture.csproj", "WkCommerce.Infrastucture/"]
COPY ["WkCommerce.Core/WkCommerce.Core.csproj", "WkCommerce.Core/"]
COPY ["WkCommerce.Application/WkCommerce.Application.csproj", "WkCommerce.Application/"]
RUN dotnet restore "WkCommerce.WebApi/WkCommerce.WebApi.csproj"
COPY . .
WORKDIR "/src/WkCommerce.WebApi"
RUN dotnet build "WkCommerce.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WkCommerce.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WkCommerce.WebApi.dll"]