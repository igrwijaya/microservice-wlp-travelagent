using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binus.Partner.Core.Domain.AggregateRoots.PartnerAggregate;
using Binus.Partner.Core.Domain.Commons;
using Binus.Partner.Core.Infrastructure.DataSources;
using Microsoft.EntityFrameworkCore;

namespace Binus.Partner.Core.Infrastructure.Repositories;

public class PartnerRepository : BaseRepository<Domain.AggregateRoots.PartnerAggregate.Partner>, IPartnerRepository
{
    public PartnerRepository(CoreDbContext context) : base(context)
    {
    }

    public Task<Domain.AggregateRoots.PartnerAggregate.Partner> ReadWithSettingsAsync(int id)
    {
        return ReadAsync(delegate(DbSet<Domain.AggregateRoots.PartnerAggregate.Partner> set)
        {
            return set.Include(item => item.Settings);
        }, item => item.Id == id);
    }

    public CoreDataTable<PartnerSetting> GetDataTableSettings(int partnerId, int page, int size)
    {
        var dbSet = Context.Set<PartnerSetting>();
        var dealsPackages = dbSet.Where(item => item.PartnerId == partnerId);
        
        return GetDataTable(
            dealsPackages,
            new CoreDataTableParameter
            {
                Start = page,
                Length = size,
                SortColumn = nameof(CoreEntity.CreatedDateTime),
                SortColumnDirection = "DESC"
            }, set => set);
    }

    public IEnumerable<PartnerSetting> GetSettings(int partnerId, int page, int size)
    {
        var dbSet = Context.Set<PartnerSetting>();
        var dealsPackageEntity = dbSet.AsQueryable().Where(item => item.PartnerId == partnerId);

        return Get(dealsPackageEntity, page, size);
    }

    public Task<PartnerSetting> ReadSettingAsync(int partnerId, int settingId)
    {
        var dbSet = Context.Set<PartnerSetting>();

        return dbSet.FirstOrDefaultAsync(item => item.PartnerId == partnerId && item.Id == settingId);
    }

    public async Task UpdateSettingAsync(PartnerSetting partnerSetting)
    {
        Context.Entry(partnerSetting).State = EntityState.Modified;
        
        await Context.SaveChangesAsync();
    }

    public async Task DeleteSettingAsync(int partnerId, int settingId)
    {
        var dbSet = Context.Set<PartnerSetting>();
        var entity = await ReadSettingAsync(partnerId, settingId);

        if (entity == null)
        {
            return;
        }

        dbSet.Remove(entity);

        await Context.SaveChangesAsync();
    }
}