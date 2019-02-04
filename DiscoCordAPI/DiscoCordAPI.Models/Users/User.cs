namespace DiscoCordAPI.Models.Users
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public User(int id, string name, byte[] passwordHash, byte[] passwordSalt)
        {
            Id = id;
            Name = name;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
