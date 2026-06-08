using PrintConnect.Data.Repositories;

namespace PrintConnect.Data;

public interface IUnitOfWork
{
    public IPrinterRepository PrinterRepository { get; }
    public IJobRepository JobRepository { get; }

    public Task<int> SaveChangesAsync();
    public int SaveChanges();
}