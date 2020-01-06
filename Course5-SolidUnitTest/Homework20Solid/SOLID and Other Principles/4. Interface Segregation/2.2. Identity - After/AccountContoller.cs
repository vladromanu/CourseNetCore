namespace InterfaceSegregationIdentityAfter
{
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;
    using InterfaceSegregationIdentityAfter.Contracts;

    public class AccountContoller : IAccount
    {
        private readonly IManager manager;
        
        private IUser User;
        private IEnumerable<IUser> UserList;
        private IEnumerable<IUser> OnlineUserList;

        public AccountContoller(IManager account)
        {
            this.manager = manager;
        }

        public void ChangePassword(string oldPass, string newPass)
        {
            this.manager.ChangePassword(oldPass, newPass);
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return this.UserList;
        }

        public IEnumerable<IUser> GetAllUsersOnline()
        {
            return this.OnlineUserList;
        }

        public IUser GetUserByName(string name)
        {
            var user = (from usr in this.UserList
                       where usr.Name.ToLower() = name.Trim().ToLower()
                       select usr).FirstOrDefault();

            if(user == null)
            {
                throw new KeyNotFoundException($"User by the name {name} was not found in the user list");
            }

            return user;
        }

        public void Login(string username, string password)
        {
            string hash = GenerateWeakPassword(password);

            var user = (from usr in this.UserList
                        where usr.Name.ToLower() = name.Trim().ToLower()
                        && usr.Password = hash
                        select usr).FirstOrDefault();
            
            if (user == null)
            {
                throw new KeyNotFoundException("Invalid login credentials");
            }

            // if user is already int the online list ..
            // ..
            if (user == null)
            {
                throw new System.Exception("User is already loged in");
            }

            // Add in the online users list ..
            //this.OnlineUserList.Add(user);
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


        public void Register(string username, string password)
        {
            // Create new user 
            string hash = GenerateWeakPassword(password);
            // .. 

            // Add it in the user list 
            // this.userList.Add();
        }

    }
}
