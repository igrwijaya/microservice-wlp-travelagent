namespace Binus.Services.Customer.API.ViewModels.CustomerViewModel;

public class UpdateCustomerVm
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Gender { get; set; }

    public string ProfilePicture { get; set; }

    public string Email { get; set; }

    public string EmailVerifiedToken { get; set; }

    public string Phone { get; set; }

    public string Country { get; set; }

    public string OAuthId { get; set; }

    public string OAuthProvider { get; set; }
}