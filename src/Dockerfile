#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PowerPlant Coding Challange/Power_Plant_Unit_Measurement/Power_Plant_Unit_Measurement.csproj", "PowerPlant Coding Challange/Power_Plant_Unit_Measurement/"]
RUN dotnet restore "PowerPlant Coding Challange/Power_Plant_Unit_Measurement/Power_Plant_Unit_Measurement.csproj"
COPY . .
WORKDIR "/src/PowerPlant Coding Challange/Power_Plant_Unit_Measurement"
RUN dotnet build "Power_Plant_Unit_Measurement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Power_Plant_Unit_Measurement.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Power_Plant_Unit_Measurement.dll"]