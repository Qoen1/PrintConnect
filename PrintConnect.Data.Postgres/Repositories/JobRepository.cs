using PrintConnect.Data.Repositories;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Data.Postgres.Repositories;

public class JobRepository: IJobRepository
{
    private readonly PrintConnectContext _context;

    public JobRepository(PrintConnectContext context)
    {
        _context = context;
    }

    public async Task<Job> AddJobToPrinterByIdAsync(Guid printerId, Job job)
    {
        if (job.PrinterId == Guid.Empty) job.PrinterId = printerId;
        await _context.Jobs.AddAsync(job);
        return job;
    }
}