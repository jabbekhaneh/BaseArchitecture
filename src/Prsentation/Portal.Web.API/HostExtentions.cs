using Portal.Application;
using Portal.Base.Options;
using Portal.Infrastructure;
namespace Portal.Web.API;

public static class HostExtentions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        
        builder.Services.BuildApplication();

        var Configurations = builder.Configuration.GetValueBaseOptions();
        
        builder.Services.BuildInfrastructure(option =>
        {
            option = Configurations;
        });
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("");

        

        app.MapControllers();

        return app;
    }

}
