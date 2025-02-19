

using INuBase.Contract.Abstractions.Message;

namespace INuBase.Contract.Services.V2.Product;
public static class Command
{
    public record CreateProductCommand(string Name, decimal Price, string Description) : ICommand;

    public record UpdateProductCommand(Guid Id, string Name, decimal Price, string Description) : ICommand;

    public record DeleteProductCommand(Guid Id) : ICommand;
}
