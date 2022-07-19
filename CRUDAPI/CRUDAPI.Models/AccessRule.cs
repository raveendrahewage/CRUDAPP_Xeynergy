using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Models
{
    public class AccessRule
    {
        [Key]
        public int AccessRuleID { get; set; }
        [Required]
        public string RuleName { get; set; }
        [Required]
        public bool Permission { get; set; }
    }
}
