FROM mcr.microsoft.com/dotnet/core/sdk:2.2

WORKDIR /src
COPY src .
RUN dotnet restore
RUN dotnet build --no-restore -c Release -o out
RUN dotnet publish --no-restore -c Release -o out
