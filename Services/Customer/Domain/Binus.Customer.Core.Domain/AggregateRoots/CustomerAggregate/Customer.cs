using Binus.Customer.Core.Domain.Commons;

namespace Binus.Customer.Core.Domain.AggregateRoots.CustomerAggregate;

public class Customer : CoreEntity, IAggregateRoot
{
    public Customer()
    {
        
    }

    public Customer(string firstName, string lastName, string gender, string profilePicture, string email, string emailVerifiedToken, string phone, string country, string oAuthId, string oAuthProvider)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        ProfilePicture = profilePicture;
        Email = email;
        EmailVerifiedToken = emailVerifiedToken;
        Phone = phone;
        Country = country;
        OAuthId = oAuthId;
        OAuthProvider = oAuthProvider;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Gender { get; private set; }

    public string ProfilePicture { get; private set; }

    public string Email { get; private set; }

    public string EmailVerifiedToken { get; private set; }

    public string Phone { get; private set; }

    public string Country { get; private set; }

    public string OAuthId { get; private set; }

    public string OAuthProvider { get; private set; }
}