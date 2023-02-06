using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Portal.Base.CQRS.Command;
using Portal.Base.CQRS.Contracts;
using Portal.Base.Options;

namespace Portal.Base;

public static class BaseFrameworkDependency
{
    public static IServiceCollection BuildBaseFramework(this IServiceCollection services,
        Action<BaseOptions> options)
    {
        services.Configure<BaseOptions>(options);
        services.BuildMediator();
        return services;
    }

    private static IServiceCollection BuildMediator(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRequestPostProcessor<,>), typeof(CommitCommandPostProcessor<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        return services;
    }
}