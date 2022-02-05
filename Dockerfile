FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# DB setup
# copy and publish db-up project
COPY src/F1.DbUp/*.csproj ./F1.DbUp/
WORKDIR /src/F1.DbUp
RUN dotnet restore

WORKDIR /src
COPY src/F1.DbUp/. ./F1.DbUp/
WORKDIR /src/F1.DbUp
RUN dotnet publish -o /publish


# copy and publish api
#WORKDIR /src
#COPY src/F1Api/*.csproj ./F1Api/
#WORKDIR /src/F1Api
#RUN dotnet restore
#
#WORKDIR /src
#COPY src/F1Api/. ./F1Api/
#WORKDIR /src/F1Api
#RUN dotnet publish -o /publish