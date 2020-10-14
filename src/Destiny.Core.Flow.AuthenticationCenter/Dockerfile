#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app
EXPOSE 80

#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["src/Destiny.Core.Flow.AuthenticationCenter/Destiny.Core.Flow.AuthenticationCenter.csproj", "src/Destiny.Core.Flow.AuthenticationCenter/"]
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
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "Destiny.Core.Flow.AuthenticationCenter.dll"]