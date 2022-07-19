using CRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Services
{
    public interface IAdminRepository
    {
        public List<Admin> AllAdmins();
        public Admin AdminByID(int ID);
        public Admin AddAdmin(Admin admin);
        public Admin UpdateAdmin(int ID, Admin admin);
        public void DeleteUser(int ID);
    }
}
