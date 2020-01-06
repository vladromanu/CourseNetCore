namespace InterfaceSegregationIdentityAfter.Contracts
{
    public interface IManager
    {
        bool RequireUniqueEmail { get; set; }

        int MinRequiredPasswordLength { get; set; }

        int MaxRequiredPasswordLength { get; set; }

        void ChangePassword(string oldPass, string newPass);
    }
}
