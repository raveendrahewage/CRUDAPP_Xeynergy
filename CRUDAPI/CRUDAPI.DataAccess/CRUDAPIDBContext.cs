using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.DataAccess
{
    public class CRUDAPIDBContext:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AccessRule> AccessRules { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3LBDLIV;Initial Catalog=Xeynergy_CRUDAPP;Integrated Security=True");
        }
    }
}
