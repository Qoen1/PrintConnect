using PrintConnect.Domain.Entities;

namespace PrintConnect.Adapter;

public interface IFileAdapter
{
    /// <summary>
    /// Gets a list of all the files on the printer. For now just the root directory.
    /// </summary>
    /// <returns></returns>
    public Task<List<PrinterFile>> GetAllFilesAsync();
}