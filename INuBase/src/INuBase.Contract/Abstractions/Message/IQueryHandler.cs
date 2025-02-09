using INuBase.Contract.Abstractions.Shared;
using MediatR;

namespace INuBase.Contract.Abstractions.Message;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{ }
