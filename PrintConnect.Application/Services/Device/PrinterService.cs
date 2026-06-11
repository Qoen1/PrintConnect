using FluentResults;
using PrintConnect.Adapter.Factories;
using PrintConnect.Application.Services.Queue;
using PrintConnect.Data;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Application.Services.Device;

public class PrinterService: IPrinterService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStatusAdapterFactory _statusAdapterFactory;
    private readonly IQueueService _queueService;

    public PrinterService(IUnitOfWork unitOfWork, IStatusAdapterFactory statusAdapterFactory, IQueueService queueService)
    {
        _unitOfWork = unitOfWork;
        _statusAdapterFactory = statusAdapterFactory;
        _queueService = queueService;
    }

    public async Task<Result<Job>> StartNextJobInQueueByIdAsync(Guid printerId)
    {
        var printer = await _unitOfWork.PrinterRepository.GetPrinterByIdAsync(printerId);
        if(printer is null) throw new Exception($"Printer {printerId} not found");
        var statusAdapter = _statusAdapterFactory.Create(printer);

        var queue = await _queueService.GetPrinterQueueByIdAsync(printerId);
        var job = queue.Jobs.First();

        var result = await statusAdapter.PrintFileAsync(job.FileName);
        if (result.IsSuccess)
        {
            job.StartedAt = DateTime.UtcNow;
        }

        await _unitOfWork.SaveChangesAsync();
        return result;
    }

    public Task<Printer?> GetPrinterInfoById(Guid printerId) => _unitOfWork.PrinterRepository.GetPrinterByIdAsync(printerId);
}