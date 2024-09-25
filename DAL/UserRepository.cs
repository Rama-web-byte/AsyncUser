using AsyncUser.Models;
using AsyncUser.Repository;
using System.Linq;

namespace AsyncUser.DAL
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = new List<User>()
        {
           new User{Id=1,Username="rama", Email="ram.thilak@gmail.com"},
           new User{Id=2,Username="siva", Email="sivara@gmail.com"}
        };

        public Task<IEnumerable<User>> GetAllUsers()
        {

            return Task.FromResult(_users.AsEnumerable());

        }


        public Task<User> GetById(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return Task.FromResult(user);
        }

        public Task<User> AddUser(User user)
        {
            var chkexistuser = _users.Any(u => u.Email == user.Email);
            if (chkexistuser == true)
            {
                throw new Exception("User Already Exist");
            }

             user.Id = _users.Count > 0 ? _users.Max(u=>u.Id) + 1 : 1;
            _users.Add(user);

            return Task.FromResult(user);
        }

        public Task UpdateUser(int id, User user)
        {
            var updateuser = _users.FirstOrDefault(u => u.Id == id);

            if (updateuser != null)
            {
                updateuser.Email = user.Email;
                updateuser.Username = user.Username;
            }

            else 
            {
                throw new Exception("User not found");
            }
            return Task.CompletedTask;
        }


        public Task DeleteUser(int id)
        {

            var deleteuser = _users.FirstOrDefault(u => u.Id == id);

            if (deleteuser != null)
            {
                _users.RemoveAt(id);
            }

            else
            {
                throw new Exception();
            }

            return Task.CompletedTask;
        }
    }
}
