using INuBase.Contract.Abstractions.Shared;
using MediatR;

namespace INuBase.Contract.Abstractions.Message;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{ }
