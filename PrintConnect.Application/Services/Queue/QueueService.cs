using PrintConnect.Data;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Application.Services.Queue;

public class QueueService: IQueueService
{
    private IUnitOfWork _unitOfWork;

    public QueueService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Printer> GetPrinterQueueByIdAsync(Guid id)
    {
        var jobs = await _unitOfWork.PrinterRepository.GetPrinterPendingJobsByIdAsync(id);
        var printer = await _unitOfWork.PrinterRepository.GetPrinterByIdAsync(id);
        if(printer is null) throw new NullReferenceException("Printer not found");
        printer.Jobs = jobs;
        return printer;
    }

    public async Task AddPrinterJobByIdAsync(Guid printerId, string filepath)
    {
        Job job = new()
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Name = filepath,
            FileName = filepath,
            PrinterId = printerId
        };
        await _unitOfWork.JobRepository.AddJobToPrinterByIdAsync(printerId, job);
        await _unitOfWork.SaveChangesAsync();
    }
}