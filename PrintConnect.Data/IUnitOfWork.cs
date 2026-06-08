namespace PrintConnect.Data;

public interface IUnitOfWork
{
    public IPrinterRepository PrinterRepository { get; }

    public Task<int> SaveChangesAsync();
    public int SaveChanges();
}