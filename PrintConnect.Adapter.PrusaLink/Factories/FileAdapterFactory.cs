using PrintConnect.Adapter.Factories;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Adapter.PrusaLink.Factories;

public class FileAdapterFactory: IFileAdapterFactory
{
    public IFileAdapter Create(Printer printer)
    {
        return new FileAdapter(printer);
    }
}