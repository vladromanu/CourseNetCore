namespace InterfaceSegregationIdentityAfter
{
    using InterfaceSegregationIdentityAfter.Contracts;

    public class AccountManager : IManager
    {
        public bool RequireUniqueEmail { get; set; }

        public int MinRequiredPasswordLength { get; set; }

        public int MaxRequiredPasswordLength { get; set; }

        public void ChangePassword(string oldPass, string newPass)
        {
            // change password
        }

    }
}
