FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build

WORKDIR /source

COPY *.sln .
COPY oceanfanatics/*.csproj ./oceanfanatics/
RUN dotnet restore

COPY oceanfanatics/. ./oceanfanatics/
WORKDIR /source/oceanfanatics
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./

VOLUME /app/App_Data/Files
VOLUME /root/.aspnet

CMD ["dotnet", "oceanfanatics.dll", "--urls", "http://0.0.0.0:5000"]
