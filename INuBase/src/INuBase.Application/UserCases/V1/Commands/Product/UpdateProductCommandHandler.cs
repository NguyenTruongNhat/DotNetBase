using INuBase.Contract.Abstractions.Message;
using INuBase.Contract.Abstractions.Shared;
using INuBase.Contract.Services.V1.Product;

namespace INuBase.Application.UserCases.V1.Commands.Product;
public class UpdateProductCommandHandler : ICommandHandler<Command.UpdateProductCommand>
{
    public async Task<Result> Handle(Command.UpdateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

    }
}
