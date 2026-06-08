using PrintConnect.Domain.Entities;

namespace PrintConnect.Data.Repositories;

public interface IPrinterRepository
{
    public Task<Printer> GetPrinterJobsByIdAsync(Guid printerId);
    public Task<Printer?> GetPrinterByIdAsync(Guid printerId);
}