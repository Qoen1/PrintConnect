using PrintConnect.Domain.Entities;

namespace PrintConnect.Data.Repositories;

public interface IJobRepository
{
    public Task<Job> AddJobToPrinterByIdAsync(Guid printerId, Job job);
}