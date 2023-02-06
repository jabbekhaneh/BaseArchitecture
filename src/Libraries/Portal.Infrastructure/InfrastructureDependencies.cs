using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Portal.Base;
using Portal.Base.CQRS.Command;
using Portal.Base.Options;
using Portal.Infrastructure.Identity;
using Portal.Infrastructure.Languages;
using Portal.Infrastructure.Localization.Languages;
using Portal.Infrastructure.Persistence;
using Portal.Infrastructure.Persistence.Repositories;
using Portal.Shared.Identity;
using Portal.Shared.Identity.Impl;
using Portal.Shared.Localization.Languages;


namespace Portal.Infrastructure;

public static class InfrastructureDependencies
{

    public static IServiceCollection BuildInfrastructure(this IServiceCollection services,
        Action<BaseOptions> options)
    {
        services.BuildBaseFramework(options);

        services.BuildEntityframework();

        services.RegisterIdentity();

        services.BuildLocalization();

        return services;
    }
    private static IServiceCollection BuildLocalization(this IServiceCollection services)
    {
        services.AddScoped<QueryLanguageRepository, DapperLanguageRepository>();
        services.AddScoped<CammandLanguageRepository, EFLanguageRepository>();
        services.AddScoped<BaseLanguageRepository, LanguageRepository>();

        return services;
    }

    private static IServiceCollection BuildEntityframework(this IServiceCollection services)
    {
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<BaseClaimService, ClaimService>();
        services.AddDbContext<DatabaseContext>();
        services.AddScoped<BaseCammandUnitOfWork, EFUnitOfWork>();

        return services;
    }

    
    private static IServiceCollection RegisterIdentity(this IServiceCollection services)
    {

        

        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DatabaseContext>();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 10;
            options.Lockout.AllowedForNewUsers = true;

            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        });

        return services;
    }

    public static IServiceCollection TokenBase(this IServiceCollection services)
    {
        services.AddAuthentication();
        services.AddAuthorization();
        services.AddAuthorization(options =>
        {
            
        });
        return services;
    }

    public static IServiceCollection CookieeBase(this IServiceCollection services)
    {
        services.AddAuthentication();
        services.AddAuthorization();
        services.Configure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, option =>
        {
            option.LogoutPath = "/";
            option.LogoutPath = "/";
            option.AccessDeniedPath = "/";
            option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            option.Cookie.Name = "PORTAL.COOKIE";
        });
        return services;
    }

}
