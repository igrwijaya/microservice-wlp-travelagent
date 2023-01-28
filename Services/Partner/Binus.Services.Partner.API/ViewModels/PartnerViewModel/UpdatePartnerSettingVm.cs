namespace Binus.Services.Partner.API.ViewModels.PartnerViewModel;

public class UpdatePartnerSettingVm
{
    public int PartnerId { get; set; }
    
    public string Group { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }
}