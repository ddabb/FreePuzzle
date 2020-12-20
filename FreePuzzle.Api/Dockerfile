#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
COPY . /app
COPY ../FreePuzzle.Service/FreePuzzle.Service.csproj /FreePuzzle.Service.csproj

WORKDIR "/app"
RUN dotnet build "FreePuzzle.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FreePuzzle.Api.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN ln -sf /usr/share/zoneinfo/Asia/Shanghai /etc/localtime && echo 'Asia/Shanghai' >/etc/timezone
ENTRYPOINT ["dotnet", "FreePuzzle.Api.dll"]
