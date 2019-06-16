FROM mcr.microsoft.com/dotnet/core/sdk:2.2
ARG BUILD_NUMBER

WORKDIR /src
COPY src .
RUN dotnet restore
RUN dotnet build -p:Version=${BUILD_NUMBER} -c Release -o out
