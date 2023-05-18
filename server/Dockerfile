FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy AS build
ARG NETENV=Release
WORKDIR /src
COPY ./ ./
RUN dotnet restore src/TotalArmyBuilder.Api/TotalArmyBuilder.Api.csproj
RUN dotnet publish src/TotalArmyBuilder.Api/TotalArmyBuilder.Api.csproj -c $NETENV -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-jammy
WORKDIR /app
COPY --from=build /app ./

ENV ASPNETCORE_URLS=http://*:5000
EXPOSE 5000

ARG API_DB_URL
ENV DbConnectionString=$API_DB_URL

# Install the agent
RUN apt-get update && apt-get install -y wget ca-certificates gnupg \
&& echo 'deb http://apt.newrelic.com/debian/ newrelic non-free' | tee /etc/apt/sources.list.d/newrelic.list \
&& wget https://download.newrelic.com/548C16BF.gpg \
&& apt-key add 548C16BF.gpg \
&& apt-get update \
&& apt-get install -y newrelic-dotnet-agent \
&& rm -rf /var/lib/apt/lists/*

ARG LICENSE_KEY
# Enable the agent
ENV CORECLR_ENABLE_PROFILING=1 \
CORECLR_PROFILER={36032161-FFC0-4B61-B559-F6C5D41BAE5A} \
CORECLR_NEWRELIC_HOME=/usr/local/newrelic-dotnet-agent \
CORECLR_PROFILER_PATH=/usr/local/newrelic-dotnet-agent/libNewRelicProfiler.so \
NEW_RELIC_LICENSE_KEY=$LICENSE_KEY \
NEW_RELIC_APP_NAME=TotalArmyBuilder

ENTRYPOINT ["dotnet", "TotalArmyBuilder.Api.dll"]