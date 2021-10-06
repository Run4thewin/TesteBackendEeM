#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TesteBackendEeM/TesteBackendEeM.csproj", "TesteBackendEeM/"]
RUN dotnet restore "TesteBackendEeM/TesteBackendEeM.csproj"
COPY . .
WORKDIR "/src/TesteBackendEeM"
RUN dotnet build "TesteBackendEeM.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteBackendEeM.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteBackendEeM.dll"]