namespace EgeYurt_Backend_Task.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public User(int id,DateTime createdDate, DateTime updateDate, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash
            , bool isDeleted) : this()
        {
            Id = id;
            CreatedDate = createdDate;
            UpdatedDate = updateDate;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            IsDeleted = isDeleted;
        }

    }
}
