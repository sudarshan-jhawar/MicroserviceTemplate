#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DSF.NexGen.UserManagementService/DSF.NexGen.UserManagementService.csproj", "DSF.NexGen.UserManagementService/"]
RUN dotnet restore "DSF.NexGen.UserManagementService/DSF.NexGen.UserManagementService.csproj"
COPY . .
WORKDIR "/src/DSF.NexGen.UserManagementService"
RUN dotnet build "DSF.NexGen.UserManagementService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSF.NexGen.UserManagementService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSF.NexGen.UserManagementService.dll"]