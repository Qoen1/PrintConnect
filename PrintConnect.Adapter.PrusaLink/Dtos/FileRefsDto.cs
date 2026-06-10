using System.Text.Json.Serialization;

namespace PrintConnect.Adapter.PrusaLink.Dtos;

public class FileRefsDto
{
    [JsonPropertyName("icon")]
    public string? Icon { get; set; }

    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; set; }

    [JsonPropertyName("download")]
    public string? Download { get; set; }
}