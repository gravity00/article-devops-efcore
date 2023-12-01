using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
// ReSharper disable InconsistentNaming
// ReSharper disable SuggestBaseTypeForParameterInConstructor

namespace ArticleDevOpsEfCore.Database;

public class Migrator(
    ILogger<Migrator> _logger,
    DatabaseContext _context
)
{
    public async ValueTask RunAsync(CancellationToken ct)
    {
        _logger.LogDebug("Migrating database to the latest version");
        await _context.Database.MigrateAsync(ct);
        _logger.LogInformation("Database migrated to latest version");
    }
}