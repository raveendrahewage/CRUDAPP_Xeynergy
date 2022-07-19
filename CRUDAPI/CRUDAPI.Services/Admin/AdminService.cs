using CRUDAPI.DataAccess;
using CRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Services
{
    public class AdminService: IAdminRepository
    {
        private readonly CRUDAPIDBContext _context = new CRUDAPIDBContext();
        public List<Admin> AllAdmins()
        {
            List<Admin> adminList = _context.Admins.ToList();
            foreach (Admin admin in adminList)
            {
                admin.UserGroup = _context.UserGroups.Find(admin.UserGroupID);
                admin.UserGroup.AccessRule = _context.AccessRules.Find(admin.UserGroup.AccessRuleID);
            }
            return adminList;
        }

        public Admin AdminByID(int ID)
        {
            Admin admin = _context.Admins.Find(ID);
            admin.UserGroup = _context.UserGroups.Find(admin.UserGroupID);
            admin.UserGroup.AccessRule = _context.AccessRules.Find(admin.UserGroup.AccessRuleID);
            return admin;
        }

        public Admin AddAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
            Admin addedAdmin = _context.Admins.Find(admin.PersonID);
            addedAdmin.UserGroup = _context.UserGroups.Find(addedAdmin.UserGroupID);
            addedAdmin.UserGroup.AccessRule = _context.AccessRules.Find(addedAdmin.UserGroup.AccessRuleID);
            return addedAdmin;
        }

        public Admin UpdateAdmin(int ID, Admin admin)
        {
            Admin adminToBeUpdated = _context.Admins.Find(ID);
            adminToBeUpdated.FirstName = admin.FirstName;
            adminToBeUpdated.LastName = admin.LastName;
            adminToBeUpdated.Email = admin.Email;
            adminToBeUpdated.Privilege = admin.Privilege;
            adminToBeUpdated.UserGroupID = admin.UserGroupID;
            _context.SaveChanges();
            adminToBeUpdated.UserGroup = _context.UserGroups.Find(admin.UserGroupID);
            adminToBeUpdated.UserGroup.AccessRule = _context.AccessRules.Find(adminToBeUpdated.UserGroup.AccessRuleID);
            return adminToBeUpdated;
        }

        public void DeleteUser(int ID)
        {
            Admin adminToBeDeleted = _context.Admins.Find(ID);
            _context.Admins.Remove(adminToBeDeleted);
            _context.SaveChanges();
        }
    }
}
