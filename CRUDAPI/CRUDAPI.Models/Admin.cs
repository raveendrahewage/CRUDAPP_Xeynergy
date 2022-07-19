using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Models
{
    public class Admin
    {
        [Key]
        public int PersonID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Privilege { get; set; }

        [Display(Name = "UserGroups")]
        public virtual int UserGroupID { get; set; }

        [ForeignKey("UserGroupID")]
        public virtual UserGroup UserGroup { get; set; }
    }
}
