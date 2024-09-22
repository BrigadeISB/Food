namespace Domain
{
    public class User
    {
        public User(string email, string passwordHash, string? firstName, string? lastName)
        {
            Id = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = null;
        }

        public string Id { get; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string Email { get; }
        public string PasswordHash { get; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
    }
}
