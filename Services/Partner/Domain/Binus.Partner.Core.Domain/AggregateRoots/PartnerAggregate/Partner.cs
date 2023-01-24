using Binus.Partner.Core.Domain.Commons;

namespace Binus.Partner.Core.Domain.AggregateRoots.PartnerAggregate;

public class Partner : CoreEntity, IAggregateRoot
{
    public Partner()
    {
        
    }

    public Partner(string brandName, string brandCode, string url, string wlpConfiguration, string logo)
    {
        BrandName = brandName;
        BrandCode = brandCode;
        Url = url;
        WlpConfiguration = wlpConfiguration;
        Logo = logo;
    }
    
    public string BrandName { get; private set; }

    public string BrandCode { get; private set; }

    public string Url { get; private set; }

    public string WlpConfiguration { get; private set; }

    public string Logo { get; private set; }
}