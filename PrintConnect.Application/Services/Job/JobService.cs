using PrintConnect.Data;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Application.Services.Job;

public class JobService: IJobService
{
    private IUnitOfWork _unitOfWork;

    public JobService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Printer> GetPrinterQueueByIdAsync(Guid id)
    {
        return _unitOfWork.PrinterRepository.GetPrinterJobsByIdAsync(id);
    }

    public async Task AddPrinterJobByIdAsync(Guid printerId, string filepath)
    {
        // await _unitOfWork.PrinterRepository.GetPrinterByIdAsync(printerId);
        Domain.Entities.Job job = new()
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Name = filepath,
            FileName = filepath,
            Progress = 0,
            PrinterId = printerId
        };
        await _unitOfWork.JobRepository.AddJobToPrinterByIdAsync(printerId, job);
        await _unitOfWork.SaveChangesAsync();
    }
}