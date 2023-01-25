using System.Collections.Generic;
using Binus.Partner.Core.Domain.Commons;

namespace Binus.Partner.Core.Domain.AggregateRoots.PartnerAggregate;

public class Partner : CoreEntity, IAggregateRoot
{
    public Partner()
    {
        
    }

    public Partner(string brandName, string brandCode, string url, string logo)
    {
        BrandName = brandName;
        BrandCode = brandCode;
        Url = url;
        Logo = logo;
    }
    
    public string BrandName { get; private set; }

    public string BrandCode { get; private set; }

    public string Url { get; private set; }
    
    public string Logo { get; private set; }

    public List<PartnerSetting> Settings { get; set; }
}