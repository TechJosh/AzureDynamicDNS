FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

RUN git clone https://github.com/TechJosh/AzureDynamicDNS.git /Source

WORKDIR /Source

RUN dotnet restore

WORKDIR /Source/azdyndns

RUN dotnet publish -c release -o /Output --no-restore

FROM mcr.microsoft.com/dotnet/runtime:6.0

RUN apt-get update && apt-get -y install cron

WORKDIR /DockerOutput/App

COPY --from=build /Output ./

RUN echo "*/1 * * * * /DockerOutput/App/azdyndns -f /DockerOutput/App/config.json" > /etc/cron.d/ddns

COPY config.json .

RUN chmod +x azdyndns

RUN chmod 0644 /etc/cron.d/ddns

RUN crontab /etc/cron.d/ddns

CMD ["cron", "-f"]