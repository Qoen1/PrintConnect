using PrintConnect.Adapter.Factories;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Adapter.PrusaLink.Factories;

public class StatusAdapterFactory: IStatusAdapterFactory
{
    public IStatusAdapter Create(Printer printer)
    {
        return new StatusAdapter(printer);
    }
}