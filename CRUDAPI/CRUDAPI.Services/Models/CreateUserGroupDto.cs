using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Services.Models
{
    public class CreateUserGroupDto
    {
        public string GroupName { get; set; }
        public int AccessRuleID { get; set; }
    }
}
