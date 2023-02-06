using MediatR;
using Microsoft.Extensions.Logging;

namespace Portal.Base.CQRS.Contracts;


public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"-- Portal_Handling_{typeof(TRequest).Name} --");
        _logger.LogInformation($"Portal_Handling_{typeof(TRequest).Name}");

        var response = await next();

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"-- Portal_Handled{typeof(TResponse).Name} --");
        _logger.LogInformation($"Portal_Handled=>{typeof(TResponse).Name}");

        return response;
    }
}