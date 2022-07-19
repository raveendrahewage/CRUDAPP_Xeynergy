using CRUDAPI.DataAccess;
using CRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Services
{
    public class UserGroupService: IUserGroupRepository
    {
        private readonly CRUDAPIDBContext _context = new CRUDAPIDBContext();
        public List<UserGroup> AllUserGroups()
        {
            List<UserGroup> userGroupList = _context.UserGroups.ToList();
            foreach(UserGroup userGroup in userGroupList)
            {
                userGroup.AccessRule = _context.AccessRules.Find(userGroup.AccessRuleID);
            }
            return userGroupList;
        }

        public UserGroup UserGroupByID(int ID)
        {
            UserGroup userGroup = _context.UserGroups.Find(ID);
            userGroup.AccessRule = _context.AccessRules.Find(userGroup.AccessRuleID);
            return userGroup;
        }

        public UserGroup AddUserGroup(UserGroup userGroup)
        {
            _context.UserGroups.Add(userGroup);
            _context.SaveChanges();
            UserGroup addedUsedGroup = _context.UserGroups.Find(userGroup.UserGroupID);
            addedUsedGroup.AccessRule = _context.AccessRules.Find(addedUsedGroup.AccessRuleID);
            return addedUsedGroup;
        }

        public UserGroup UpdateUserGroup(int ID, UserGroup userGroup)
        {
            UserGroup userGroupToBeUpdated = _context.UserGroups.Find(ID);
            userGroupToBeUpdated.GroupName = userGroup.GroupName;
            userGroupToBeUpdated.AccessRuleID = userGroup.AccessRuleID;
            _context.SaveChanges();
            userGroupToBeUpdated.AccessRule = _context.AccessRules.Find(userGroup.AccessRuleID);
            return userGroupToBeUpdated;
        }

        public void DeleteUserGroup(int ID)
        {
            UserGroup userGroupToBeDeleted = _context.UserGroups.Find(ID);
            _context.UserGroups.Remove(userGroupToBeDeleted);
            _context.SaveChanges();
        }
    }
}
