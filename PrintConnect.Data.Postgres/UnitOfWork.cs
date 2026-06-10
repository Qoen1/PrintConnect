using PrintConnect.Data.Postgres.Repositories;
using PrintConnect.Data.Repositories;

namespace PrintConnect.Data.Postgres;

public class UnitOfWork: IUnitOfWork
{
    private PrintConnectContext _context;

    public UnitOfWork(PrintConnectContext context)
    {
        _context = context;
    }

    public IPrinterRepository PrinterRepository
    {
        get
        {
            if (field is null)
            {
                field = new PrinterRepository(_context);
            }
            return field;
        }
    }

    public IJobRepository JobRepository 
    {
        get
        {
            if (field is null)
            {
                field = new JobRepository(_context);
            }
            return field;
        }
    }

    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

    public int SaveChanges() => _context.SaveChanges();
}