#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["src/Destiny.Core.Flow.API/Destiny.Core.Flow.API.csproj", "src/Destiny.Core.Flow.API/"]
#COPY ["src/Destiny.Core.Flow.AutoMapper/Destiny.Core.Flow.AutoMapper.csproj", "src/Destiny.Core.Flow.AutoMapper/"]
#COPY ["src/Destiny.Core.Flow/Destiny.Core.Flow.csproj", "src/Destiny.Core.Flow/"]
#COPY ["src/Destiny.Core.Flow.Model/Destiny.Core.Flow.Model.csproj", "src/Destiny.Core.Flow.Model/"]
#COPY ["src/Destiny.Core.Flow.IdentityServer.Entities/Destiny.Core.Flow.IdentityServer.Entities.csproj", "src/Destiny.Core.Flow.IdentityServer.Entities/"]
#COPY ["src/Destiny.Core.Flow.Identity/Destiny.Core.Flow.Identitys.csproj", "src/Destiny.Core.Flow.Identity/"]
#COPY ["src/Destiny.Core.Flow.EntityFrameworkCore/Destiny.Core.Flow.EntityFrameworkCore.csproj", "src/Destiny.Core.Flow.EntityFrameworkCore/"]
#COPY ["src/Destiny.Core.Flow.IdentityServer4/Destiny.Core.Flow.IdentityServer.csproj", "src/Destiny.Core.Flow.IdentityServer4/"]
#COPY ["src/Destiny.Core.Flow.Swagger/Destiny.Core.Flow.Swagger.csproj", "src/Destiny.Core.Flow.Swagger/"]
#COPY ["src/Destiny.Core.Flow.IServices/Destiny.Core.Flow.IServices.csproj", "src/Destiny.Core.Flow.IServices/"]
#COPY ["src/Destiny.Core.Flow.Dtos/Destiny.Core.Flow.Dtos.csproj", "src/Destiny.Core.Flow.Dtos/"]
#COPY ["src/Destiny.Core.Flow.FluentValidation/Destiny.Core.Flow.FluentValidation.csproj", "src/Destiny.Core.Flow.FluentValidation/"]
#COPY ["src/Destiny.Core.Flow.MiniProfiler/Destiny.Core.Flow.MiniProfiler.csproj", "src/Destiny.Core.Flow.MiniProfiler/"]
#COPY ["src/Destiny.Core.Flow.SeriLog/Destiny.Core.Flow.SeriLog.csproj", "src/Destiny.Core.Flow.SeriLog/"]
#COPY ["src/Destiny.Core.Flow.Caching.CSRedis/Destiny.Core.Flow.Caching.CSRedis.csproj", "src/Destiny.Core.Flow.Caching.CSRedis/"]
#COPY ["src/Destiny.Core.Flow.Caching/Destiny.Core.Flow.Caching.csproj", "src/Destiny.Core.Flow.Caching/"]
#COPY ["src/Destiny.Core.Flow.AspNetCore/Destiny.Core.Flow.AspNetCore.csproj", "src/Destiny.Core.Flow.AspNetCore/"]
#COPY ["src/Destiny.Core.Flow.Services/Destiny.Core.Flow.Services.csproj", "src/Destiny.Core.Flow.Services/"]
#COPY ["src/Destiny.Core.Flow.Repository/Destiny.Core.Flow.Repository.csproj", "src/Destiny.Core.Flow.Repository/"]
#COPY ["src/Destiny.Core.Flow.MongoDB/Destiny.Core.Flow.MongoDB.csproj", "src/Destiny.Core.Flow.MongoDB/"]
#COPY ["src/Destiny.Core.Flow.CodeGenerator/Destiny.Core.Flow.CodeGenerator.csproj", "src/Destiny.Core.Flow.CodeGenerator/"]
#RUN dotnet restore "src/Destiny.Core.Flow.API/Destiny.Core.Flow.API.csproj"
COPY . .
#WORKDIR "/src/src/Destiny.Core.Flow.API"
#RUN dotnet build "Destiny.Core.Flow.API.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Destiny.Core.Flow.API.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Destiny.Core.Flow.API.dll"]