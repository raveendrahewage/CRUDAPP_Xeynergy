using CRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Services
{
    public interface IUserGroupRepository
    {
        public List<UserGroup> AllUserGroups();
        public UserGroup UserGroupByID(int ID);
        public UserGroup AddUserGroup(UserGroup userGroup);
        public UserGroup UpdateUserGroup(int ID, UserGroup userGroup);
        public void DeleteUserGroup(int ID);
    }
}
