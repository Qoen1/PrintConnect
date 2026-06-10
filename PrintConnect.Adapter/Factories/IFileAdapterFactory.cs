using PrintConnect.Domain.Entities;

namespace PrintConnect.Adapter.Factories;

public interface IFileAdapterFactory
{
    public IFileAdapter Create(Printer printer);
}