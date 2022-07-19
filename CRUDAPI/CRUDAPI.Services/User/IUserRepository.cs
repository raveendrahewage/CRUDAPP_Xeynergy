using CRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Services
{
    public interface IUserRepository
    {
        public List<User> AllUsers();
        public User UserByID(int ID);
        public User AddUser(User user);
        public User UpdateUser(int ID, User user);
        public void DeleteUser(int ID);
    }
}
