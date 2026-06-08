using Microsoft.EntityFrameworkCore;
using PrintConnect.Data.Repositories;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Data.Postgres.Repositories;

public class PrinterRepository: IPrinterRepository
{
    private PrintConnectContext _context;

    public PrinterRepository(PrintConnectContext context)
    {
        _context = context;
    }

    public Task<Printer> GetPrinterJobsByIdAsync(Guid printerId)
    {
        return _context.Printers.Where(x => x.Id == printerId).Include(x => x.Jobs).FirstOrDefaultAsync();
    }

    public Task<Printer?> GetPrinterByIdAsync(Guid printerId)
    {
        return _context.Printers.Where(x => x.Id == printerId).FirstOrDefaultAsync();
    }
}