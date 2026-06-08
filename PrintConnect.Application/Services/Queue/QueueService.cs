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

    public Task<Printer> GetPrinterQueueByIdAsync(Guid id)
    {
        return _unitOfWork.PrinterRepository.GetPrinterJobsByIdAsync(id);
    }
}