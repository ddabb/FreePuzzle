#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
COPY . /app
#将dockfile上一级目录的所有文件拷贝到当前app目录
WORKDIR "/app/FreePuzzle.UI"
RUN dotnet build "FreePuzzle.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FreePuzzle.UI.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN ln -sf /usr/share/zoneinfo/Asia/Shanghai /etc/localtime && echo 'Asia/Shanghai' >/etc/timezone
ENTRYPOINT ["dotnet", "FreePuzzle.UI.dll"]
