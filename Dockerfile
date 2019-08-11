#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["Ger_Garage/Ger_Garage.csproj", "Ger_Garage/"]
RUN dotnet restore "Ger_Garage/Ger_Garage.csproj"
COPY . .
WORKDIR "/src/Ger_Garage"
RUN dotnet build "Ger_Garage.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ger_Garage.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ger_Garage.dll"]