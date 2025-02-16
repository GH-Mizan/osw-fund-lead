FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/OSW.Web.Host/OSW.Web.Host.csproj", "src/OSW.Web.Host/"]
COPY ["src/OSW.Web.Core/OSW.Web.Core.csproj", "src/OSW.Web.Core/"]
COPY ["src/OSW.Application/OSW.Application.csproj", "src/OSW.Application/"]
COPY ["src/OSW.Core/OSW.Core.csproj", "src/OSW.Core/"]
COPY ["src/OSW.EntityFrameworkCore/OSW.EntityFrameworkCore.csproj", "src/OSW.EntityFrameworkCore/"]
WORKDIR "/src/src/OSW.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/OSW.Web.Host", "src/OSW.Web.Host"]
COPY ["src/OSW.Web.Core", "src/OSW.Web.Core"]
COPY ["src/OSW.Application", "src/OSW.Application"]
COPY ["src/OSW.Core", "src/OSW.Core"]
COPY ["src/OSW.EntityFrameworkCore", "src/OSW.EntityFrameworkCore"]
WORKDIR "/src/src/OSW.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "OSW.Web.Host.dll"]
