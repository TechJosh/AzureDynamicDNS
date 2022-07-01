# Azure DNS - Dynamic DNS

**Now with Docker** - That has been running beautifully for nearly a month.

Customized .NET 6 appplication based on https://github.com/FrodeHus/azure-dyndns

Used to update one or more DNS A records within an Azure DNS Zone to the IP of the host machine.

## Usage
|Short|Long              |Info                                                               |
|-----|------------------|-------------------------------------------------------------------|
|-f   |--config-file     |Path to configuration file                                         |
|-g   |--resource-group  |Azure resource group where Azure DNS is located                    |
|-z   |--zone            |Azure DNS zone name                                                |
|-r   |--record          |DNS record name to be created/updated                              |
|-s   |--subscription-id |Azure subscription ID                                              |
|-t   |--tenant-id       |Azure tenant ID (or set AZURE_TENANT_ID)                           |
|-c   |--client-id       |Azure service principal client ID (or set AZURE_CLIENT_ID)         |
|-x   |--client-secret   |Azure service principal client secret (or set AZURE_CLIENT_SECRET) |
|-t   |--ttl             |DNS Record TTL                                                     |
|     |--help            |Display this help screen.                                          |
|     |--version         |Display version information.                                       |

## Example Config File
See [config.example.json](azdyndns/config.example.json)
```json
{
  "subscriptionId": "",
  "resourceGroup": "",
  "zoneName": "",
  "recordName": "",
  "clientId": "",
  "clientSecret": "",
  "tenantId": "",
  "ttl": 3600,
  "additionalRecords": [
    {
      "resourceGroup": "",
      "zoneName": "",
      "recordName": ""
    }
  ]
}
```

## Notes
- ```addtionalRecords``` is optional within the config file.
- This can be run to be updated as often as necessary via Task Scheduler on Windows or as a cron task on Linux. For example:

    ```
    ## Run every 15 minutes with the config.json file.
    */15 * * * * /srv/azdyndns/azdyndns -f /etc/azdyndns/config.json
    ```

## Docker
See [ReadMe](azdyndns-docker/README.MD)

## Nuget Dependencies
https://www.nuget.org/packages/CommandLineParser/
https://www.nuget.org/packages/Microsoft.Azure.Management.Dns
https://www.nuget.org/packages/Microsoft.Rest.ClientRuntime.Azure.Authentication/

## Version History
See [ChangeLog](CHANGELOG.MD)
