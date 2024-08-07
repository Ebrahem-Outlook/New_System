using New_System.Domain.Core.BaseType;
using New_System.Domain.Users.Events;
using New_System.Domain.Users.ValueObjects;

namespace New_System.Domain.Users;

public sealed class User : AggregateRoot<UserId>
{
    private User(FirstName firstName, LastName lastName, Email email, Password password)
        : base(UserId.Create())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    private User() : base() { }

    public FirstName FirstName { get; private set; } = default!;
    public LastName LastName { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Password Password { get; private set; } = default!;

    public static User Create(FirstName firstName, LastName lastName, Email email, Password password)
    {
        User user = new(firstName, lastName, email, password);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user));

        return user;
    }

    public void UpdateUser(FirstName firstName, LastName lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        RaiseDomainEvent(new UserUpdatedDomainEvent(this));
    }

    public void UpdateEmail(Email email)
    {
        Email = email;

        RaiseDomainEvent(new EmailUpdatedDomainEvent(this));
    }

    public void UpdatePassword(Password password)
    {
        Password = password;

        RaiseDomainEvent(new PasswordUpdatedDomainEvent(this));
    }
}
