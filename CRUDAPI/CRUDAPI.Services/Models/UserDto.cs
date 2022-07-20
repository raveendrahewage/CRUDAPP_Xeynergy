using CRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Services.Models
{
    public class UserDto
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AttachedCustomerID { get; set; }
        public int UserGroupID { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}
