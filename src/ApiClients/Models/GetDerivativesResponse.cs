using System.Text.Json.Serialization;

namespace ApiClients.Models
{
    public class GetDerivativesResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}