using FluentResults;

namespace PrintConnect.Application.Services.Device;

public interface IPrinterService
{
    public Task<Result<Domain.Entities.Job>> StartNextJobInQueueByIdAsync(Guid printerId);
}