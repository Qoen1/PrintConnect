using PrintConnect.Domain.Entities;

namespace PrintConnect.Application.Services.File;

public interface IFileService
{
    public Task<List<PrinterFile>> GetPrinterFilesByIdAsync(Guid printerId);
}