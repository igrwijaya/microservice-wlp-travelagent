using Binus.Partner.Core.Domain.Commons;

namespace Binus.Partner.Core.Domain.AggregateRoots.PartnerAggregate;

public class PartnerSetting : CoreEntity
{
    public PartnerSetting()
    {
        
    }

    public PartnerSetting(int partnerId, string group, string key, string value)
    {
        PartnerId = partnerId;
        Group = group;
        Key = key;
        Value = value;
    }

    public int PartnerId { get; private set; }
    
    public string Group { get; private set; }

    public string Key { get; private set; }

    public string Value { get; private set; }

    public Partner Partner { get; set; }
}