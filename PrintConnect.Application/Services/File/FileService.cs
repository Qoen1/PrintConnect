using PrintConnect.Adapter.Factories;
using PrintConnect.Data;
using PrintConnect.Data.Repositories;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Application.Services.File;

public class FileService: IFileService
{
    private readonly IPrinterRepository _printerRepository;
    private readonly IFileAdapterFactory _fileAdapterFactory;

    public FileService(IUnitOfWork unitOfWork, IFileAdapterFactory fileAdapterFactory)
    {
        _fileAdapterFactory = fileAdapterFactory;
        _printerRepository = unitOfWork.PrinterRepository;
    }

    public async Task<List<PrinterFile>> GetPrinterFilesByIdAsync(Guid printerId)
    {
        var printer = await _printerRepository.GetPrinterByIdAsync(printerId);
        if (printer is null) throw new Exception("Printer not found");//TODO: throw better exceptions
        var adapter = _fileAdapterFactory.Create(printer);
        var files = await adapter.GetAllFilesAsync();
        return files;
    }
}