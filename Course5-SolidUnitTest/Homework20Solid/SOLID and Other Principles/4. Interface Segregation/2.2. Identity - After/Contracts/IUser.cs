namespace InterfaceSegregationIdentityAfter.Contracts
{
    public interface IUser
    {
        string Name { get; }

        string Email { get; }

        string PasswordHash { get; }

        bool Online { get; set; }
    }
}
