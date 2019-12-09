FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
RUN ls
COPY Brook.Signalr.Api/Brook.Signalr.Api.csproj Brook.Signalr.Api/
RUN dotnet restore "Brook.Signalr.Api/Brook.Signalr.Api.csproj"
COPY . .
WORKDIR "/src/Brook.Signalr.Api"
RUN dotnet build "Brook.Signalr.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Brook.Signalr.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
RUN ln -sf /usr/share/zoneinfo/Asia/Shanghai /etc/localtime && echo 'Asia/Shanghai' >/etc/timezone
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Brook.Signalr.Api.dll"]
