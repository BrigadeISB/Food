namespace Domain.Users
{
    public interface IUserRepository
    {
        //Task GetByIdAsync(string id);
        Task AddAsync(User? user);
        Task<User?> GetByEmailAsync(string email);
        //Task DeleteAsync(User? user);
    }
}
