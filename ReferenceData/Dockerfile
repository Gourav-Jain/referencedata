FROM mcr.microsoft.com/dotnet/core/sdk:3.0

WORKDIR /app

COPY ./bin/Debug/netcoreapp3.0 .
EXPOSE 80
ENTRYPOINT ["dotnet", "ReferenceData.dll"]