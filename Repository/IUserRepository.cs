using AsyncUser.Models;

namespace AsyncUser.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetById(int id);
        Task<User> AddUser(User user);
        Task DeleteUser(int id);
        Task  UpdateUser(int id,User user);


    }
}
