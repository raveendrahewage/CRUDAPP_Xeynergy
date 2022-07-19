using CRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Services.Models
{
    public class AdminDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Privilege { get; set; }
        public int UserGroupID { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}
