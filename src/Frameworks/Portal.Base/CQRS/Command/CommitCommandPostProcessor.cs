using MediatR;
using MediatR.Pipeline;
using Portal.Base.CQRS.Contracts;


namespace Portal.Base.CQRS.Command;
public class CommitCommandPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly BaseCammandUnitOfWork _UOW;
    public CommitCommandPostProcessor(BaseCammandUnitOfWork uow)
    {
        _UOW = uow;
    }

    public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
    {
        if (request is CommittableRequest)
        {
            await _UOW.CommitAsync();
        }
        //return await next();

    }
}