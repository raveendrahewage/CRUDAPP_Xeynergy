using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDAPI.DataAccess;
using CRUDAPI.Models;
using CRUDAPI.Services;

namespace CRUDAPI.Services
{
    public class AccessRuleService: IAccessRuleRepository
    {
        private readonly CRUDAPIDBContext _context = new CRUDAPIDBContext();
        public List<AccessRule> AllAccessRules()
        {
            return _context.AccessRules.ToList();
        }

        public AccessRule AccessRuleByID(int ID)
        {
            return _context.AccessRules.Find(ID);
        }

        public AccessRule AddAccessRule(AccessRule accessRule)
        {
            _context.AccessRules.Add(accessRule);
            _context.SaveChanges();
            return _context.AccessRules.Find(accessRule.AccessRuleID);
        }

        public AccessRule UpdateAccessRule(int ID,AccessRule accessRule)
        {
            AccessRule accessRuleToBeUpdated = _context.AccessRules.Find(ID);
            accessRuleToBeUpdated.RuleName = accessRule.RuleName;
            accessRuleToBeUpdated.Permission = accessRule.Permission;
            _context.SaveChanges();
            return accessRuleToBeUpdated;
        }

        public void DeleteAccessRule(int ID)
        {
            AccessRule accessRuleToBeDeleted = _context.AccessRules.Find(ID);
            _context.AccessRules.Remove(accessRuleToBeDeleted);
            _context.SaveChanges();
        }
    }
}
