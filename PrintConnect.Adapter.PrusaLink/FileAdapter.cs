using System.Net.Http.Json;
using PrintConnect.Adapter.PrusaLink.Dtos;
using PrintConnect.Adapter.PrusaLink.Helpers;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Adapter.PrusaLink;

public class FileAdapter : IFileAdapter
{
    private readonly PrusalinkClientFactory _clientFactory;

    public FileAdapter(Printer printer)
    {
        _clientFactory = new PrusalinkClientFactory(printer);
    }

    public async Task<List<PrinterFile>> GetAllFilesAsync()
    {
        var client = _clientFactory.Create();
        var path = "/usb";
        List<PrinterFile> files = [];
        
        await TraverseFolderAsync(path, files, client);

        return files;
    }
    
    private async Task TraverseFolderAsync(
        string folderPath,
        List<PrinterFile> files, 
        HttpClient client)
    {
        var folder = await client.GetFromJsonAsync<FileDto>(
            $"/api/v1/files{folderPath}");

        

        if (folder?.Children == null)
            return;

        foreach (var item in folder.Children)
        {
            switch (item.Type)
            {
                case "PRINT_FILE":
                    files.Add(new PrinterFile
                    {
                        DisplayName = item.DisplayName,
                        Name = item.Name,
                        Path = folderPath,
                        // DisplayName = item.DisplayName ?? item.Name,
                        // DownloadUrl = item.Refs?.Download ?? "",
                        // Modified = item.ModifiedTimestamp.HasValue
                        //     ? DateTimeOffset.FromUnixTimeSeconds(
                        //         item.ModifiedTimestamp.Value)
                        //     : null
                    });
                    break;

                case "FOLDER":
                    var childPath = $"{folderPath}/{item.Name}";
                    await TraverseFolderAsync(childPath, files, client);
                    break;
            }
        }
    }
}