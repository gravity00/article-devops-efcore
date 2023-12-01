using ArticleDevOpsEfCore.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);

ConfigureLogging(
    builder.Logging
);

ConfigureServices(
    builder.Services,
    builder.Configuration
);

using var host = builder.Build();

return;

static void ConfigureLogging(
    ILoggingBuilder logging
)
{
    // configure other logging providers, like NLog, Serilog or even Application Insights
}

static void ConfigureServices(
    IServiceCollection services,
    IConfiguration configuration
)
{
    var connectionString = configuration.GetConnectionString("ArticleDevOpsEfCore");
    services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(
        connectionString,
        o => o.MigrationsAssembly(typeof(Program).Assembly.FullName)
    ), ServiceLifetime.Singleton);
}