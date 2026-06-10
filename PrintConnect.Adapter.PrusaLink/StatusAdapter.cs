using System.Net;
using FluentResults;
using PrintConnect.Adapter.PrusaLink.Helpers;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Adapter.PrusaLink;

public class StatusAdapter(Printer printer) : IStatusAdapter
{
    private readonly PrusalinkClientFactory _clientFactory = new(printer);
    public async Task<Result> PrintFileAsync(string filePath)
    {
        var client = _clientFactory.Create();
        var content = new StringContent(string.Empty);
        var response = await client.PostAsync($"/api/v1/files{filePath}", content);
        if (response.StatusCode == HttpStatusCode.NoContent)
        {
            return Result.Ok();
        }
        return Result.Fail($"Received incorrect response code ({response.StatusCode}) from printer");
    }
}