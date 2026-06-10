using System.Text.Json.Serialization;

namespace PrintConnect.Adapter.PrusaLink.Dtos;

public class FileDto
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = "";

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("ro")]
    public bool ReadOnly { get; set; }

    [JsonPropertyName("m_timestamp")]
    public long? ModifiedTimestamp { get; set; }

    [JsonPropertyName("children")]
    public List<FileDto>? Children { get; set; }

    [JsonPropertyName("refs")]
    public FileRefsDto? Refs { get; set; }
}