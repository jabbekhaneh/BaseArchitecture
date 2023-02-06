using Microsoft.Extensions.Configuration;

namespace Portal.Base.Options;

public static class ConfigurationBinderExtentions
{
    public static BaseOptions GetValueBaseOptions(this IConfiguration configuration)
    {
        return configuration.GetSection("Configurations").Get<BaseOptions>();
    }
}
