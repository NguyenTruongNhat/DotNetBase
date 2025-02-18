using INuBase.Contract.Abstractions.Message;
using INuBase.Contract.Abstractions.Shared;
using INuBase.Contract.Services.V1.Product;

namespace INuBase.Application.UserCases.V1.Commands.Product;
public class DeleteProductCommandHandler : ICommandHandler<Command.DeleteProductCommand>
{
    public async Task<Result> Handle(Command.DeleteProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
