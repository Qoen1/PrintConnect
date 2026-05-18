using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using PrintConnect.Adapter.PrusaLink;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Client.Pages;

public partial class Dashboard : ComponentBase
{
    private DashboardForm _form = new();
    
    
    public Printer? Printer { get; set; }
    public List<string>? Files { get; set; }
    
    private async Task OnServerDataSubmitted()
    {
        
        var credentials = new NetworkCredential(
            _form.Username, 
            _form.Password
        );

        // Handler configured for Digest Auth
        var handler = new HttpClientHandler
        {
            Credentials = credentials,
            PreAuthenticate = false
        };

        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(_form.Url);
            var response = await client.GetFromJsonAsync<FolderInfo>("/api/v1/files/usb/");
            Files = response.children.Select(x => x.name).ToList();
        }
        // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Digest", $"{_form.Username}:{_form.Password}");
    }
}

public class DashboardForm
{
    public string Url { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}