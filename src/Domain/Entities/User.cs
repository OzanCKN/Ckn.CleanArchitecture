namespace Ckn.Domain.Entities;

using Ckn.Domain.Common;
using Ckn.Domain.Enums;
using Ckn.Domain.Events;
using Ckn.Domain.ValueObjects;

public class User : AggregateRoot<Guid>
{
    public string UserName { get; private set; }
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? PhoneNumber { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public List<string> Roles { get; private set; }
    public UserType UserType { get; private set; }
    public decimal? CommissionRate { get; private set; }

    protected User() { }

    public User(
        Guid id,
        string userName,
        Email email,
        string passwordHash,
        string firstName,
        string lastName,
        string? phoneNumber,
        bool isActive,
        DateTime createdAt,
        DateTime? updatedAt,
        List<string>? roles,
        UserType userType,
        decimal? commissionRate = null
    ) : base(id)
    {
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        IsActive = isActive;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Roles = roles ?? new List<string>();
        UserType = userType;
        CommissionRate = commissionRate;
    }

    public static User Create(
        string userName,
        Email email,
        string passwordHash,
        string firstName,
        string lastName,
        UserType userType,
        decimal? commissionRate = null,
        string? phoneNumber = null,
        List<string>? roles = null
    )
    {
        var user = new User(
            Guid.NewGuid(),
            userName,
            email,
            passwordHash,
            firstName,
            lastName,
            phoneNumber,
            true,
            DateTime.UtcNow,
            null,
            roles,
            userType,
            commissionRate
        );
        user.AddDomainEvent(new UserCreatedEvent(user));
        return user;
    }

    public void UpdateProfile(string firstName, string lastName, string? phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetPassword(string passwordHash)
    {
        PasswordHash = passwordHash;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetActive(bool isActive)
    {
        IsActive = isActive;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddRole(string role)
    {
        if (!Roles.Contains(role))
            Roles.Add(role);
    }

    public void RemoveRole(string role)
    {
        Roles.Remove(role);
    }
}
