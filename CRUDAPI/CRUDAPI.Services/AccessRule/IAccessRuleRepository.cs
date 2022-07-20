using CRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Services
{
    public interface IAccessRuleRepository
    {
        public List<AccessRule> AllAccessRules();
        public AccessRule AccessRuleByID(int ID);
        public AccessRule AddAccessRule(AccessRule accessRule);
        public AccessRule UpdateAccessRule(int ID, AccessRule accessRule);
        public void DeleteAccessRule(int ID);
        public List<User> AccessRuleUserList(int ID);
    }
}
