using System.Collections.Generic;
using System.Threading.Tasks;
using Binus.Partner.Core.Domain.Commons;

namespace Binus.Partner.Core.Domain.AggregateRoots.PartnerAggregate;

public interface IPartnerRepository : IBaseRepository<Partner>
{
    #region Partner Settings

    Task<Partner> ReadWithSettingsAsync(int id);
    
    CoreDataTable<PartnerSetting> GetDataTableSettings(int partnerId, int page, int size);
    
    IEnumerable<PartnerSetting> GetSettings(int partnerId, int page, int size);

    Task<PartnerSetting> ReadSettingAsync(int partnerId, int settingId);

    Task UpdateSettingAsync(PartnerSetting partnerSetting);

    Task DeleteSettingAsync(int partnerId, int settingId);

    #endregion
}