using Microsoft.Azure.Management.Dns;
using Microsoft.Azure.Management.Dns.Models;
using Microsoft.Rest.Azure.Authentication;
using System.Text.Json;

public partial class Program
{
    private static async Task UpdateDNSRecords(Options o)
    {
        if (!string.IsNullOrEmpty(o.ConfigFile) && File.Exists(o.ConfigFile))
        {
            // Load Settings from Configuration File
            try
            {
                o = JsonSerializer.Deserialize<Options>(File.ReadAllText(o.ConfigFile)) ?? o;
            }
            catch (Exception)
            {
            }
        }

        if (string.IsNullOrEmpty(o.ResourceGroup)) throw new NullReferenceException("Invalid Resource Group. Ensure resourceGroup argument or configuration is set.");
        if (string.IsNullOrEmpty(o.Zone)) throw new NullReferenceException("Invalid Zone Name. Ensure zoneName argument or configuration is set.");
        if (string.IsNullOrEmpty(o.Record)) throw new NullReferenceException("Invalid Record Name. Ensure recordName argument or configuration is set.");
        if (string.IsNullOrEmpty(o.SubscriptionId)) throw new NullReferenceException("Invalid Subscription ID. Ensure subscriptionId argument or configuration is set.");

        var (tenantId, clientId, clientSecret) = GetCredentialInfo(o);

        if (string.IsNullOrEmpty(tenantId)) throw new NullReferenceException("Invalid Tenant ID. Ensure tenantId argument, configuration or Environment Variable (AZURE_TENANT_ID) is set.");
        if (string.IsNullOrEmpty(clientId)) throw new NullReferenceException("Invalid Client ID. Ensure clientId argument, configuration or Environment Variable (AZURE_CLIENT_ID) is set.");
        if (string.IsNullOrEmpty(clientSecret)) throw new NullReferenceException("Invalid Client Secret. Ensure clientSecret argument, configuration or Environment Variable (AZURE_CLIENT_SECRET) is set.");

        var creds = await ApplicationTokenProvider.LoginSilentAsync(tenantId, clientId, clientSecret);

        var dnsClient = new DnsManagementClient(creds);
        dnsClient.SubscriptionId = o.SubscriptionId;

        var ipAddr = await GetPublicIPAddress();

        var recordSet = new RecordSet()
        {
            TTL = 3600,
            ARecords = new List<ARecord>()
                {
                    new ARecord(ipAddr)
                },
            Metadata = new Dictionary<string, string>()
                {
                    { "updated", DateTime.UtcNow.ToString() }
                }
        };

        var result = await dnsClient.RecordSets.CreateOrUpdateAsync(o.ResourceGroup, o.Zone, o.Record, RecordType.A, recordSet);

        Console.WriteLine(JsonSerializer.Serialize(result));
    }

    private static async Task<string> GetPublicIPAddress()
    {
        var client = new HttpClient();
        return await client.GetStringAsync("https://ifconfig.me");
    }

    private static (string, string, string) GetCredentialInfo(Options o)
    {
        return (
            o.TenantId ?? Environment.GetEnvironmentVariable("AZURE_TENANT_ID") ?? string.Empty,
            o.ClientId ?? Environment.GetEnvironmentVariable("AZURE_CLIENT_ID") ?? string.Empty,
            o.ClientSecret ?? Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET") ?? string.Empty
        );
    }
}
