namespace InterfaceSegregationIdentityAfter.Contracts
{
    class User : IUser
    {
        private string name;
        private string email;
        private string passwordHash;
        private bool online;

        public User(string username, string hash)
        {
            this.email = username;
            this.passwordHash = hash;
            this.Online = false;
            this.name = username;
        }

        public string Name => this.name;

        public string Email => this.email;

        public string PasswordHash => this.passwordHash;

        public bool Online { get => this.online; set => this.online = value; }
    }
}
