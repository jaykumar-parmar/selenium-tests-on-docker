FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
COPY . .
RUN dotnet build "SeleniumTest.csproj" -c Release -o /app
ENTRYPOINT ["dotnet", "test", "--logger:trx"]
