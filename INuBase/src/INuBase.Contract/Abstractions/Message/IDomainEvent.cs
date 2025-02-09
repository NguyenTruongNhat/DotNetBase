using MediatR;

namespace INuBase.Contract.Abstractions.Message;
public interface IDomainEvent : INotification
{
    public Guid Id { get; init; }
}
