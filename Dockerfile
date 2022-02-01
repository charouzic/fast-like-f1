FROM mcr.microsoft.com/dotnet/core/sdk:3.1.100 AS build

# DB setup
# copy and publish db-up project
COPY src/Services.Pax.ReservationQuery.DbUp/*.csproj ./Services.Pax.ReservationQuery.DbUp/
WORKDIR /src/Services.Pax.ReservationQuery.DbUp
RUN dotnet restore

WORKDIR /src
COPY src/Services.Pax.ReservationQuery.DbUp/. ./Services.Pax.ReservationQuery.DbUp/
WORKDIR /src/Services.Pax.ReservationQuery.DbUp
RUN dotnet publish -c Release -o out


# copy and publish api
WORKDIR /src
COPY src/Services.Pax.ReservationQuery.Api/*.csproj ./Services.Pax.ReservationQuery.Api/
WORKDIR /src/Services.Pax.ReservationQuery.Api
RUN dotnet restore

WORKDIR /src
COPY src/Services.Pax.ReservationQuery.Api/. ./Services.Pax.ReservationQuery.Api/
WORKDIR /src/Services.Pax.ReservationQuery.Api
RUN dotnet publish -c Release -o out