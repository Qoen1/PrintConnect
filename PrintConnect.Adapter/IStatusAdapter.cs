using FluentResults;

namespace PrintConnect.Adapter;

public interface IStatusAdapter
{
    public Task<Result> PrintFileAsync(string filePath);
}