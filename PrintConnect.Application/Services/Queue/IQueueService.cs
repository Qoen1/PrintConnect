using PrintConnect.Domain.Entities;

namespace PrintConnect.Application.Services.Queue;

public interface IQueueService
{
    public Task<Printer> GetPrinterQueueByIdAsync(Guid id);
    public Task AddPrinterJobByIdAsync(Guid printerId, string filepath);
}