using System.Threading.Tasks;
using Binus.Accommodation.Core.Infrastructure.DataSources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Binus.Services.Accommodation.API.Infrastructures;

public class AutoMigration : IAutoMigration
{
    private readonly CoreDbContext _coreDbContext;
    private readonly IMigrationsModelDiffer _migrationsModelDiffer;
    private readonly IMigrationsAssembly _migrationsAssembly;

    public AutoMigration(CoreDbContext coreDbContext, IMigrationsModelDiffer migrationsModelDiffer, IMigrationsAssembly migrationsAssembly)
    {
        _coreDbContext = coreDbContext;
        _migrationsModelDiffer = migrationsModelDiffer;
        _migrationsAssembly = migrationsAssembly;
    }

    public void Migrate()
    {
        var pendingModelChanges =
            _migrationsModelDiffer.GetDifferences(_migrationsAssembly.ModelSnapshot?.Model.GetRelationalModel(), _coreDbContext.Model.GetRelationalModel());

        var x = pendingModelChanges;
    }
}