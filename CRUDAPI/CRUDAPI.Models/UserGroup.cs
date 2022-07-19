using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Models
{
    public class UserGroup
    {
        [Key]
        public int UserGroupID { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Display(Name = "AccessRules")]
        public virtual int AccessRuleID { get; set; }

        [ForeignKey("AccessRuleID")]
        public virtual AccessRule AccessRule { get; set; }
    }
}
