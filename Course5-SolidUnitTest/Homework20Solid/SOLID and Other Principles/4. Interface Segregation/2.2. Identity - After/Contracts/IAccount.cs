namespace InterfaceSegregationIdentityAfter.Contracts
{
    using System.Collections.Generic;

    public interface IAccount
    {
        void Register(string username, string password);

        void Login(string username, string password);

        IEnumerable<IUser> GetAllUsersOnline();

        IEnumerable<IUser> GetAllUsers();

        IUser GetUserByName(string name);
    }
}
