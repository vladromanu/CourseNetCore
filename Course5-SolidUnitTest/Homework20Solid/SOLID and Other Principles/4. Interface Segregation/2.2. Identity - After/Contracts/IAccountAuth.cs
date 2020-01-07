namespace InterfaceSegregationIdentityAfter.Contracts
{
    interface IAccountAuth : IEmailValidation
    {
        void Register(string username, string password);

        void Login(string username, string password);
    }
}
