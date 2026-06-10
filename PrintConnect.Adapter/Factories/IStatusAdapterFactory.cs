using PrintConnect.Domain.Entities;

namespace PrintConnect.Adapter.Factories;

public interface IStatusAdapterFactory
{
    public IStatusAdapter Create(Printer printer);
}