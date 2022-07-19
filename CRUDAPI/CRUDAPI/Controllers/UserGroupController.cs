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
    [Route("api/usergroup")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private IUserGroupRepository _userGroupRepository;

        public UserGroupController(IUserGroupRepository repository)
        {
            _userGroupRepository = repository;
        }

        [HttpGet]
        public IActionResult GetAllUserGroups()
        {
            return Ok(_userGroupRepository.AllUserGroups());
        }

        [HttpGet("{ID}")]
        public IActionResult GetUserGroupByID(int ID)
        {
            UserGroup foundUserGroup = _userGroupRepository.UserGroupByID(ID);
            if (foundUserGroup is null) return NotFound();
            else return Ok(foundUserGroup);
        }

        [HttpPost]
        public IActionResult AddUserGroup(CreateUserGroupDto userGroup)
        {
            UserGroup newUserGroup = new UserGroup
            {
                GroupName = userGroup.GroupName,
                AccessRuleID = userGroup.AccessRuleID
            };
            return Ok(_userGroupRepository.AddUserGroup(newUserGroup));
        }

        [HttpPut("{ID}")]
        public IActionResult UpdateUserGroup(int ID, CreateUserGroupDto userGroup)
        {
            UserGroup foundUserGroup = _userGroupRepository.UserGroupByID(ID);
            if (foundUserGroup is null) return NotFound();
            else
            {
                UserGroup changedUserGroup = new UserGroup
                {
                    GroupName = userGroup.GroupName,
                    AccessRuleID = userGroup.AccessRuleID
                };
                return Ok(_userGroupRepository.UpdateUserGroup(ID, changedUserGroup));
            };
        }
        [HttpDelete("{ID}")]
        public IActionResult DeleteUserGroup(int ID)
        {
            UserGroup foundUserGroup = _userGroupRepository.UserGroupByID(ID);
            if (foundUserGroup is null) return NotFound();
            else
            {
                _userGroupRepository.DeleteUserGroup(ID);
                return Ok();
            }
        }
    }
}
