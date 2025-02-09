using MediatR;

namespace INuBase.Contract.Abstractions.Message;
public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}
