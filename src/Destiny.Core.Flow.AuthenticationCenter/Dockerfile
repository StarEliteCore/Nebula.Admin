#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["src/Destiny.Core.Flow.AuthenticationCenter/Destiny.Core.Flow.AuthenticationCenter.csproj", "src/Destiny.Core.Flow.AuthenticationCenter/"]
#COPY ["src/Destiny.Core.Flow.AutoMapper/Destiny.Core.Flow.AutoMapper.csproj", "src/Destiny.Core.Flow.AutoMapper/"]
#COPY ["src/Destiny.Core.Flow/Destiny.Core.Flow.csproj", "src/Destiny.Core.Flow/"]
#COPY ["src/Destiny.Core.Flow.Model/Destiny.Core.Flow.Model.csproj", "src/Destiny.Core.Flow.Model/"]
#COPY ["src/Destiny.Core.Flow.IdentityServer.Entities/Destiny.Core.Flow.IdentityServer.Entities.csproj", "src/Destiny.Core.Flow.IdentityServer.Entities/"]
#COPY ["src/Destiny.Core.Flow.Identity/Destiny.Core.Flow.Identitys.csproj", "src/Destiny.Core.Flow.Identity/"]
#COPY ["src/Destiny.Core.Flow.EntityFrameworkCore/Destiny.Core.Flow.EntityFrameworkCore.csproj", "src/Destiny.Core.Flow.EntityFrameworkCore/"]
#COPY ["src/Destiny.Core.Flow.IdentityServer4/Destiny.Core.Flow.IdentityServer.csproj", "src/Destiny.Core.Flow.IdentityServer4/"]
#COPY ["src/Destiny.Core.Flow.SeriLog/Destiny.Core.Flow.SeriLog.csproj", "src/Destiny.Core.Flow.SeriLog/"]
#COPY ["src/Destiny.Core.Flow.AspNetCore/Destiny.Core.Flow.AspNetCore.csproj", "src/Destiny.Core.Flow.AspNetCore/"]
#RUN dotnet restore "src/Destiny.Core.Flow.AuthenticationCenter/Destiny.Core.Flow.AuthenticationCenter.csproj"
COPY . .
#WORKDIR "/src/src/Destiny.Core.Flow.AuthenticationCenter"
#RUN dotnet build "Destiny.Core.Flow.AuthenticationCenter.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Destiny.Core.Flow.AuthenticationCenter.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Destiny.Core.Flow.AuthenticationCenter.dll"]