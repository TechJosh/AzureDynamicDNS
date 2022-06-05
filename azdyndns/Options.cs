using CommandLine;
using System.Text.Json.Serialization;

public class Options
{
    [JsonIgnore]
    [Option('f', "config-file", HelpText = "Path to configuration file")]
    public string? ConfigFile { get; set; }

    [JsonPropertyName("resourceGroup")]
    [Option('g', "resource-group", HelpText = "Azure resource group where Azure DNS is located")]
    public string? ResourceGroup { get; set; }

    [JsonPropertyName("zoneName")]
    [Option('z', "zone", HelpText = "Azure DNS zone name")]
    public string? Zone { get; set; }

    [JsonPropertyName("recordName")]
    [Option('r', "record", HelpText = "DNS record name to be created/updated")]
    public string? Record { get; set; }

    [JsonPropertyName("subscriptionId")]
    [Option('s', "subscription-id", HelpText = "Azure subscription ID")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("tenantId")]
    [Option('t', "tenant-id", HelpText = "Azure tenant ID (or set AZURE_TENANT_ID)")]
    public string? TenantId { get; set; }

    [JsonPropertyName("clientId")]
    [Option('c', "client-id", HelpText = "Azure service principal client ID (or set AZURE_CLIENT_ID)")]
    public string? ClientId { get; set; }

    [JsonPropertyName("clientSecret")]
    [Option('x', "client-secret", HelpText = "Azure service principal client secret (or set AZURE_CLIENT_SECRET)")]
    public string? ClientSecret { get; set; }

    [JsonPropertyName("ttl")]
    [Option('t', "ttl", HelpText = "DNS Record TTL")]
    public int? TTL { get; set; }

    [JsonPropertyName("additionalRecords")]
    public List<AdditionalRecord>? AdditionalRecords { get; set; }
}
