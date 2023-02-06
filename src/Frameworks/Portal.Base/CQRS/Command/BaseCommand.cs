using MediatR;
using Portal.Base.Common;
using Portal.Base.CQRS.Contracts;

namespace Portal.Base.CQRS.Command;

public interface BaseCommand<TResponse>  : IRequest<BaseResult<TResponse>> , CommittableRequest
{
    
}
public interface BaseCommandHandler<TCommand, TResponse> :        IRequestHandler<TCommand,BaseResult<TResponse>> where TCommand : BaseCommand<TResponse> 

{
    
}

