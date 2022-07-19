using CRUDAPI.DataAccess;
using CRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Services
{
    public class UserService: IUserRepository
    {
        private readonly CRUDAPIDBContext _context = new CRUDAPIDBContext();
        public List<User> AllUsers()
        {
            List<User> userList = _context.Users.ToList();
            foreach (User user in userList)
            {
                user.UserGroup = _context.UserGroups.Find(user.UserGroupID);
                user.UserGroup.AccessRule = _context.AccessRules.Find(user.UserGroup.AccessRuleID);
            }
            return userList;
        }

        public User UserByID(int ID)
        {
            User user = _context.Users.Find(ID);
            user.UserGroup = _context.UserGroups.Find(user.UserGroupID);
            user.UserGroup.AccessRule = _context.AccessRules.Find(user.UserGroup.AccessRuleID);
            return user;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            User addedUser = _context.Users.Find(user.PersonID);
            addedUser.UserGroup = _context.UserGroups.Find(addedUser.UserGroupID);
            addedUser.UserGroup.AccessRule = _context.AccessRules.Find(addedUser.UserGroup.AccessRuleID);
            return addedUser;
        }

        public User UpdateUser(int ID, User user)
        {
            User userToBeUpdated = _context.Users.Find(ID);
            userToBeUpdated.FirstName = user.FirstName;
            userToBeUpdated.LastName = user.LastName;
            userToBeUpdated.Email = user.Email;
            userToBeUpdated.AttachedCustomerID = user.AttachedCustomerID;
            userToBeUpdated.UserGroupID = user.UserGroupID;
            _context.SaveChanges();
            userToBeUpdated.UserGroup = _context.UserGroups.Find(user.UserGroupID);
            userToBeUpdated.UserGroup.AccessRule = _context.AccessRules.Find(userToBeUpdated.UserGroup.AccessRuleID);
            return userToBeUpdated;
        }

        public void DeleteUser(int ID)
        {
            User userToBeDeleted = _context.Users.Find(ID);
            _context.Users.Remove(userToBeDeleted);
            _context.SaveChanges();
        }
    }
}
