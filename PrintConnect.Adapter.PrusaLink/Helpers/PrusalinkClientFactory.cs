using System.Net;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Adapter.PrusaLink.Helpers;

public class PrusalinkClientFactory
{
    private readonly Printer _printer;

    public PrusalinkClientFactory(Printer printer)
    {
        _printer = printer;
    }

    public HttpClient Create()
    {
        var credentials = new NetworkCredential(_printer.Username, _printer.Password);

        // Handler configured for Digest Auth
        var handler = new HttpClientHandler
        {
            Credentials = credentials,
            PreAuthenticate = false
        };

        var client = new HttpClient(handler);
        client.BaseAddress = new Uri(_printer.Url);
        return client;
    }
}