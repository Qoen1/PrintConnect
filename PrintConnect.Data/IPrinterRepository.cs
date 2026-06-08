using PrintConnect.Domain.Entities;

namespace PrintConnect.Data;

public interface IPrinterRepository
{
    public Task<Printer> GetPrinterJobsByIdAsync(Guid printerId);
}