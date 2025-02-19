using INuBase.Contract.Abstractions.Message;
using INuBase.Contract.Abstractions.Shared;
using INuBase.Contract.Services.V1.Product;
using Microsoft.Extensions.Logging;

namespace INuBase.Application.UserCases.V1.Commands.Product;
public class CreateProductCommandHandler : ICommandHandler<Command.CreateProductCommand>
{
    private readonly ILogger<CreateProductCommandHandler> _logger;
    public CreateProductCommandHandler(ILogger<CreateProductCommandHandler> logger)
    {
        _logger = logger;
    }
    public async Task<Result> Handle(Command.CreateProductCommand request, CancellationToken cancellationToken)
    {
        _logger.LogError("Test Logger");
        Console.WriteLine("CreateProductCommand");

        return Result.Success();
    }
}
