using CRUDAPI.Models;
using CRUDAPI.Services;
using CRUDAPI.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminRepository _adminRepository;

        public AdminController(IAdminRepository repository)
        {
            _adminRepository = repository;
        }

        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            List<Admin> adminList = _adminRepository.AllAdmins();
            List<AdminDto> adminDtoList = new List<AdminDto>();
            foreach (Admin user in adminList)
            {
                adminDtoList.Add(new AdminDto
                {
                    FullName = user.FirstName + " " + user.LastName,
                    Email = user.Email,
                    Privilege = user.Privilege,
                    UserGroupID = user.UserGroupID,
                    UserGroup = user.UserGroup
                });
            }
            return Ok(adminDtoList);
        }

        [HttpGet("{ID}")]
        public IActionResult GetAdminByID(int ID)
        {
            Admin foundUser = _adminRepository.AdminByID(ID);
            if (foundUser is null) return NotFound();
            else
            {
                AdminDto adminDto = new AdminDto
                {
                    FullName = foundUser.FirstName + " " + foundUser.LastName,
                    Email = foundUser.Email,
                    Privilege = foundUser.Privilege,
                    UserGroupID = foundUser.UserGroupID,
                    UserGroup = foundUser.UserGroup
                };
                return Ok(adminDto);
            };
        }

        [HttpPost]
        public IActionResult AddAdmin(CreateAdminDto admin)
        {
            Admin newAdmin = new Admin
            {
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Email = admin.Email,
                Privilege = admin.Privilege,
                UserGroupID = admin.UserGroupID,
            };
            Admin addedAdmin = _adminRepository.AddAdmin(newAdmin);
            AdminDto adminDto = new AdminDto
            {
                FullName = addedAdmin.FirstName + " " + addedAdmin.LastName,
                Email = addedAdmin.Email,
                Privilege = addedAdmin.Privilege,
                UserGroupID = addedAdmin.UserGroupID,
                UserGroup = addedAdmin.UserGroup
            };
            return Ok(adminDto);
        }

        [HttpPut("{ID}")]
        public IActionResult UpdateAdmin(int ID, CreateAdminDto admin)
        {
            Admin foundAdmin = _adminRepository.AdminByID(ID);
            if (foundAdmin is null) return NotFound();
            else
            {
                Admin changedAdmin = new Admin
                {
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Email = admin.Email,
                    Privilege = admin.Privilege,
                    UserGroupID = admin.UserGroupID
                };
                Admin updatedAdmin = _adminRepository.UpdateAdmin(ID, changedAdmin);
                AdminDto adminDto = new AdminDto
                {
                    FullName = updatedAdmin.FirstName + " " + updatedAdmin.LastName,
                    Email = updatedAdmin.Email,
                    Privilege = updatedAdmin.Privilege,
                    UserGroupID = updatedAdmin.UserGroupID,
                    UserGroup = updatedAdmin.UserGroup
                };
                return Ok(adminDto);
            };
        }
        [HttpDelete("{ID}")]
        public IActionResult DeleteAdmin(int ID)
        {
            Admin foundAdmin = _adminRepository.AdminByID(ID);
            if (foundAdmin is null) return NotFound();
            else
            {
                _adminRepository.DeleteUser(ID);
                return Ok();
            }
        }
    }
}
