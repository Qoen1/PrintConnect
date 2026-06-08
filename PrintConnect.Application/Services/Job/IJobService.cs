using PrintConnect.Domain.Entities;

namespace PrintConnect.Application.Services.Job;

public interface IJobService
{
    public Task<Printer> GetPrinterQueueByIdAsync(Guid id);
    public Task AddPrinterJobByIdAsync(Guid printerId, string filepath);
}