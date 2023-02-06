using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Portal.Application.Localization.Languages.Add;
using System.Reflection;

namespace Portal.Application;

public static class ApplicationDependency
{
    public static IServiceCollection BuildApplication(this IServiceCollection services)
    {
        services.BuildLocalization();
        return services;
    }


    private static IServiceCollection BuildLocalization(this IServiceCollection services)
    {
        services.AddMediatR(typeof(AddLanguageCommnad).GetTypeInfo().Assembly);
        return services;
    }


}
