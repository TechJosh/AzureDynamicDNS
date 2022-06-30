# Azure Dynamic DNS - Docker

## Setup
- Ensure config.json file is up to date with proper configuration. See [ReadMe](../README.MD) for config information.
- Run the following command to execute the docker-compose script. (This may differ if you are running a version of docker with docker compose built in.)

```
docker-compose up -d
```

## Notes
- This sets up the script to execute every 15 minutes to update your Azure DNS records specified in the config.
- No ports are necessary to be open. Ensure your container has internet access to look up the host IP as well as access Azure.