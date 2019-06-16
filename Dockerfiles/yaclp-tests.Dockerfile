ARG BUILD_NUMBER
FROM yaclp:$BUILD_NUMBER AS build-container
FROM mcr.microsoft.com/dotnet/core/sdk:2.2

WORKDIR /app
COPY --from=build-container /src .

ENTRYPOINT [ "dotnet", "test" ]
