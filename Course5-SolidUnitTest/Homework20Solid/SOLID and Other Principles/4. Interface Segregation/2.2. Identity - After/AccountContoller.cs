namespace InterfaceSegregationIdentityAfter
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using InterfaceSegregationIdentityAfter.Contracts;

    public class AccountContoller : IAccount, IAccountAuth
    {
        private readonly IManager manager;

        private List<IUser> UserList;

        bool IEmailValidation.RequireUniqueEmail { get; set; }
        int IEmailValidation.MinRequiredPasswordLength { get; set; }
        int IEmailValidation.MaxRequiredPasswordLength { get; set; }


        public AccountContoller(IManager manager)
        {
            this.manager = manager;
        }

        // IManager implementations 
        public void ChangePassword(string oldPass, string newPass)
        {
            this.manager.ChangePassword(oldPass, newPass);
        }

        // IAccount implementations 
        public IEnumerable<IUser> GetAllUsers()
        {
            return this.UserList;
        }

        public IEnumerable<IUser> GetAllUsersOnline()
        {
            List<IUser> OnlineUsers = this.UserList.FindAll((i) =>
            {
                return i.Online;
            });

            return OnlineUsers;
        }

        public IUser GetUserByName(string name)
        {
            IUser user = (from usr in this.UserList
                        where usr.Name.ToLower() == name.Trim().ToLower()
                        select usr).FirstOrDefault();

            if(user == null)
            {
                throw new KeyNotFoundException($"User by the name {name} was not found in the user list");
            }

            return user;
        }

        // IAccountAuth implementations
        public void Login(string username, string password)
        {
            string hash = GenerateWeakPassword(password);

            IUser user = (from usr in this.UserList
                        where usr.Email == username.Trim() && usr.PasswordHash == hash
                        select usr).FirstOrDefault();

            if (user == null)
            {
                throw new KeyNotFoundException("Invalid login credentials");
            }

            if (user.Online == true)
            {
                throw new System.InvalidOperationException("User is already loged in");
            }

            // Put it online
            user.Online = true;

        }
        public void Register(string username, string password)
        {
            // validate 
            // RequireUniqueEmail
            // MinRequiredPasswordLength
            // MaxRequiredPasswordLength
            // ...

            string hash = GenerateWeakPassword(password);

            // And in the list
            User user = new User(username, hash);
            this.UserList.Add(user);
        }



        public string GenerateWeakPassword(string input)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
 
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

    }
}
