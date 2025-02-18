using INuBase.Contract.Abstractions.Message;
using INuBase.Contract.Abstractions.Shared;
using INuBase.Contract.Services.V1.Product;

namespace INuBase.Application.UserCases.V1.Commands.Product;
public class CreateProductCommandHandler : ICommandHandler<Command.CreateProductCommand>
{
    public async Task<Result> Handle(Command.CreateProductCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("CreateProductCommand");

        return Result.Success();
    }
}
