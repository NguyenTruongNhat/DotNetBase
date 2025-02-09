using INuBase.Contract.Abstractions.Shared;
using MediatR;

namespace INuBase.Contract.Abstractions.Message;
public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
