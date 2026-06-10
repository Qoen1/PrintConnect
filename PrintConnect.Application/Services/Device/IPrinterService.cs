using FluentResults;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Application.Services.Device;

public interface IPrinterService
{
    public Task<Result<Domain.Entities.Job>> StartNextJobInQueueByIdAsync(Guid printerId);
    public Task<Printer?> GetPrinterInfoById(Guid printerId);
}