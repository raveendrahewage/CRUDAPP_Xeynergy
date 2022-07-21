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
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository repository)
        {
            _userRepository = repository;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            List<User> userList = _userRepository.AllUsers();
            List<UserDto> userDtoList = new List<UserDto>();
            foreach(User user in userList)
            {
                userDtoList.Add(new UserDto
                {
                    PersonID = user.PersonID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email =user.Email,
                    AttachedCustomerID=user.AttachedCustomerID,
                    UserGroupID=user.UserGroupID,
                    UserGroup = user.UserGroup
                });
            }
            return Ok(userDtoList);
        }

        [HttpGet("{ID}")]
        public IActionResult GetUserByID(int ID)
        {
            User foundUser = _userRepository.UserByID(ID);
            if (foundUser is null) return NotFound("User not found!");
            else {
                UserDto userDto = new UserDto
                {
                    PersonID=foundUser.PersonID,
                    FirstName = foundUser.FirstName,
                    LastName = foundUser.LastName,
                    Email = foundUser.Email,
                    AttachedCustomerID = foundUser.AttachedCustomerID,
                    UserGroupID = foundUser.UserGroupID,
                    UserGroup=foundUser.UserGroup
                };
                return Ok(userDto);
            };
        }

        [HttpPost]
        public IActionResult AddUser(CreateUserDto user)
        {
            User newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email= user.Email,
                AttachedCustomerID= user.AttachedCustomerID,
                UserGroupID=user.UserGroupID,
            };
            User addedUser = _userRepository.AddUser(newUser);
            UserDto userDto = new UserDto
            {
                PersonID = addedUser.PersonID,
                FirstName = addedUser.FirstName,
                LastName = addedUser.LastName,
                Email = addedUser.Email,
                AttachedCustomerID = addedUser.AttachedCustomerID,
                UserGroupID = addedUser.UserGroupID,
                UserGroup = addedUser.UserGroup
            };
            return Ok(userDto);
        }

        [HttpPut("{ID}")]
        public IActionResult UpdateUser(int ID, CreateUserDto user)
        {
            User foundUser = _userRepository.UserByID(ID);
            if (foundUser is null) return NotFound("User not found!");
            else
            {
                User changedUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    AttachedCustomerID = user.AttachedCustomerID,
                    UserGroupID = user.UserGroupID
                };
                User updatedUser = _userRepository.UpdateUser(ID, changedUser);
                UserDto userDto = new UserDto
                {
                    PersonID = updatedUser.PersonID,
                    FirstName = updatedUser.FirstName,
                    LastName = updatedUser.LastName,
                    Email = updatedUser.Email,
                    AttachedCustomerID = updatedUser.AttachedCustomerID,
                    UserGroupID = updatedUser.UserGroupID,
                    UserGroup=updatedUser.UserGroup
                };
                return Ok(userDto);
            };
        }
        [HttpDelete("{ID}")]
        public IActionResult DeleteUser(int ID)
        {
            User foundUser = _userRepository.UserByID(ID);
            if (foundUser is null) return NotFound("User not found!");
            else
            {
                _userRepository.DeleteUser(ID);
                return Ok();
            }
        }
    }
}
