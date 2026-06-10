using PrintConnect.Domain.Entities;

namespace PrintConnect.Data.Repositories;

public interface IPrinterRepository
{
    public Task<List<Job>> GetPrinterPendingJobsByIdAsync(Guid printerId);
    public Task<Printer?> GetPrinterByIdAsync(Guid printerId);
}