using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Services
{
    public class CreateAccessRuleDto
    {
        public string RuleName { get; set; }
        public bool Permission { get; set; }
    }
}
