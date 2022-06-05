using System.Text.Json.Serialization;

public class AdditionalRecord
{
    [JsonPropertyName("resourceGroup")]
    public string? ResourceGroup { get; set; }

    [JsonPropertyName("zoneName")]
    public string? Zone { get; set; }

    [JsonPropertyName("recordName")]
    public string? Record { get; set; }
}